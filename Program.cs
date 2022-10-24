internal class Program
{
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello!!, Welcome To My Game: \n");
        Console.WriteLine("Player 1 Please Enter Your Name: ");
        string player1 = Console.ReadLine();
        Console.WriteLine($"\nHello, {player1}, You Play As A \"X\" \n");
        Console.WriteLine("Player 2 Please Enter Your Name: ");
        string player2 = Console.ReadLine();
        Console.WriteLine($"\nHello, {player2}, You Play As A \"O\" ");

        Console.WriteLine($"{player1}, You Will Be First");
        Console.Clear();

        int turn =1, score1 = 0, score2 = 0, choice = 0;
        bool winFlag = false, playing = true, correctInput = false;

        while(playing == true)
        {
            while (winFlag == false)
            {
                setBoard();

                Console.WriteLine("Score: {0} - {1}     {2} - {3}",player1, score1, player2, score2);

                if(turn == 1)
                {
                    Console.WriteLine($"\n{player1}(X) Its Your Turn:\n");
                }
                if (turn == 2)
                {
                    Console.WriteLine($"\n{player2}(O) Its Your Turn:\n");
                }
                while(correctInput == false)
                {
                    Console.WriteLine("Chose Your Mark Position On Board");
                    choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 10)
                    {
                        correctInput = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                correctInput = false; // reset

                if(turn == 1)
                {
                    if (boardPos[choice] == "O") // Checks to see if spot is taken already
                    {
                        Console.WriteLine("This Spot Is Alredy Taken");
                        Console.WriteLine("Plese Chose A Diffrent Spot");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        boardPos[choice] = "X";
                    }
                }

                if(turn == 2)
                {
                    if (boardPos[choice] == "X") // Checks to see if spot is taken already
                    {
                        Console.WriteLine("This Spot Is Alredy Taken");
                        Console.WriteLine("Plese Chose A Diffrent Spot");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        boardPos[choice] = "O";
                    }
                }

                winFlag = CheckWin(); // check if somone won

                if(winFlag == false)
                {
                    if(turn == 1)
                    {
                        turn = 2;
                    }
                    else if(turn == 2)
                    {
                        turn = 1;
                    }
                    Console.Clear();
                }
            }
            Console.Clear();

            setBoard();

            for(int i = 1; i < 10; i++) // reset board
            {
                boardPos[i] = i.ToString();
            }

            if(winFlag == false) // draw option
            {
                Console.WriteLine("It's a draw!");
                Console.WriteLine("Score: {0} - {1}     {2} - {3}\n", player1, score1, player2, score2);
                Console.WriteLine("What would you like to do now?");
                Console.WriteLine("1. Play again");
                Console.WriteLine("2. Leave");

                while(correctInput == false)
                {
                    Console.WriteLine("Enter your option: ");
                    choice = int.Parse(Console.ReadLine());

                    if (choice > 0 && choice < 3)
                    {
                        correctInput = true;
                    }
                }

                correctInput = false; //reset

                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!");
                        Console.ReadLine();
                        playing = false;
                        break;
                }
            }
            if (winFlag == true) // Someone won 
            {
                if (turn == 1)
                {
                    score1++;
                    Console.WriteLine("{0} wins!", player1);
                    Console.WriteLine("What would you like to do now?");
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Leave");

                    while (correctInput == false)
                    {
                        Console.WriteLine("Enter your option: ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice > 0 && choice < 3)
                        {
                            correctInput = true;
                        }
                    }

                    correctInput = false; // Reset 

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            winFlag = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            playing = false;
                            break;
                    }
                }

                if (turn == 2) // winner message
                {
                    score2++;
                    Console.WriteLine("{0} wins!", player2);
                    Console.WriteLine("What would you like to do now?");
                    Console.WriteLine("1. Play again");
                    Console.WriteLine("2. Leave");

                    while (correctInput == false)
                    {
                        Console.WriteLine("Enter your option: ");
                        choice = int.Parse(Console.ReadLine());

                        if (choice > 0 && choice < 3)
                        {
                            correctInput = true;
                        }
                    }

                    correctInput = false; // Reset 

                    switch (choice) 
                    {
                        case 1:
                            Console.Clear();
                            winFlag = false;
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            playing = false;
                            break;
                    }
                }
            }
        }
    }

    static string[] boardPos = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };//board draw
    static void setBoard()
    {
        Console.Clear();
        Console.WriteLine(" ________________________________ ");
        Console.WriteLine("|          |          |          |");
        Console.WriteLine("|     {0}    |     {1}    |     {2}    |", boardPos[1], boardPos[2], boardPos[3]);
        Console.WriteLine("|__________|__________|__________|");
        Console.WriteLine("|          |          |          |");
        Console.WriteLine("|     {0}    |     {1}    |     {2}    |", boardPos[4], boardPos[5], boardPos[6]);
        Console.WriteLine("|__________|__________|__________|");
        Console.WriteLine("|          |          |          |");
        Console.WriteLine("|     {0}    |     {1}    |     {2}    |", boardPos[7], boardPos[8], boardPos[9]);
        Console.WriteLine("|__________|__________|__________|");
        Console.WriteLine("\n");
    }

    static bool CheckWin() //  method that check if there is a winner
    {
        if (boardPos[1] == "O" && boardPos[2] == "O" && boardPos[3] == "O") 
        {
            return true;
        }
        else if (boardPos[4] == "O" && boardPos[5] == "O" && boardPos[6] == "O")
        {
            return true;
        }
        else if (boardPos[7] == "O" && boardPos[8] == "O" && boardPos[9] == "O")
        {
            return true;
        }

        else if (boardPos[1] == "O" && boardPos[5] == "O" && boardPos[9] == "O") 
        {
            return true;
        }
        else if (boardPos[7] == "O" && boardPos[5] == "O" && boardPos[3] == "O")
        {
            return true;
        }

        else if (boardPos[1] == "O" && boardPos[4] == "O" && boardPos[7] == "O")
        {
            return true;
        }
        else if (boardPos[2] == "O" && boardPos[5] == "O" && boardPos[8] == "O")
        {
            return true;
        }
        else if (boardPos[3] == "O" && boardPos[6] == "O" && boardPos[9] == "O")
        {
            return true;
        }

        if (boardPos[1] == "X" && boardPos[2] == "X" && boardPos[3] == "X") 
        {
            return true;
        }
        else if (boardPos[4] == "X" && boardPos[5] == "X" && boardPos[6] == "X")
        {
            return true;
        }
        else if (boardPos[7] == "X" && boardPos[8] == "X" && boardPos[9] == "X")
        {
            return true;
        }

        else if (boardPos[1] == "X" && boardPos[5] == "X" && boardPos[9] == "X") 
            return true;
        }
        else if (boardPos[7] == "X" && boardPos[5] == "X" && boardPos[3] == "X")
        {
            return true;
        }

        else if (boardPos[1] == "X" && boardPos[4] == "X" && boardPos[7] == "X") 
        {
            return true;
        }
        else if (boardPos[2] == "X" && boardPos[5] == "X" && boardPos[8] == "X")
        {
            return true;
        }
        else if (boardPos[3] == "X" && boardPos[6] == "X" && boardPos[9] == "X")
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}