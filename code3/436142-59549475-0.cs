                char[,] array = new char[20, Console.BufferWidth];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (i > 0 && array[i - 1, j] == ' ')
                        {
                            array[i, j] = ' ';
                            Console.Write(' ');
                        }
                        else
                        {
                            int x = getRandom.Next(10);
                            switch (x)
                            {
                                case 0:
                                    array[i, j] = ' ';
                                    Console.Write(' ');
                                    break;
                                default:
                                    array[i, j] = 'x';
                                    Console.Write('x');
                                    break;
                            }
                        }
                    }
                    Console.WriteLine();
                }
