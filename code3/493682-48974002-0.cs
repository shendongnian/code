     for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                  
                    if (i == 0)
                    {
                        Console.Write(j);
                    }
                    else
                    {
                        if(j == 0)
                        {
                            Console.Write(i);
                        }
                        else
                        {
                            Console.Write(i * j);
                        }
                    }
                }
                Console.Write("\n");
            }
