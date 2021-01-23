    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace FunnyStuff
    {
        class Program
        {
            static void Main(string[] args)
            {
                bool GameOver = true;
                int playerX = 1;
                int playerY = 1;
    
                int[] enemy = new int[2];
                Random random = new Random();
                int randomNumber = random.Next(0, 100);
                enemy[0] = random.Next(1, 15);
                enemy[1] = random.Next(1, 6);
                char[,] myCharArray = new char[16, 8];
                string[] lol = new string[8];
                lol[0] = "----------------";
                lol[1] = "-              -";
                lol[2] = "-              -";
                lol[3] = "-              -";
                lol[4] = "-              -";
                lol[5] = "-              -";
                lol[6] = "-              -";
                lol[7] = "----------------";
    
                for (int i = 0; i < 8; i++)
                {
                    char[] letters = lol[i].ToCharArray();
    
                    for (int j = 0; j < 16; j++)
                    {
                        myCharArray[j, i] = letters[j];
                    }
                }
    
                do
                {
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            if (playerX == j && playerY == i)
                            {
                                Console.Write('*');
                            }
                            else if (enemy[0] == j && enemy[1] == i)
                            {
                                Console.Write('+');
                            }
                            else
                            {
                                Console.Write(myCharArray[j, i]);
                            }
                        }
                        Console.WriteLine();
                    }
    
                    int rx = random.Next(-1, 2);
                    int ry = random.Next(-1, 2);
                    enemy[0] = (rx+enemy[0] != 1 || rx+enemy[0] != 14) ? rx+enemy[0] : enemy[0];
                    enemy[1] = (ry + enemy[1] != 1 || ry + enemy[0] != 6) ? ry + enemy[1] : enemy[1];
    
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    Console.WriteLine(pressedKey.Key.ToString());
                    if (pressedKey.Key.ToString() == "A")
                    {
                        if (playerX != 1) 
                        playerX--;
                    }
                    if (pressedKey.Key.ToString() == "S")
                    {
                        if (playerY != 6)
                        playerY++;
                    }
                    if (pressedKey.Key.ToString() == "D")
                    {
                        if (playerX != 14)
                        playerX++;
                    }
                    if (pressedKey.Key.ToString() == "W")
                    {
                        if (playerY != 1) 
                        playerY--;
                    }
    
                    if (playerX == enemy[0] && playerY == enemy[1])
                    {
                        GameOver = false;
                    }
    
                    Console.Clear();
                } while (GameOver );
    
            }
        }
    }
