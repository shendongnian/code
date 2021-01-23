                    int arrsize = Convert.ToInt32(Console.ReadLine());
                    int[] arr = new int[arrsize];
                    int month = Convert.ToInt32(Console.ReadLine());//input from the user
                    List<int> source = new List<int>();
                    while (month <= arrsize)
                    {
                        source.Add(month);
                        month++;
                    }
                    if (source.Count < arrsize)
                    {
                        for (int i = 1; i < source[0]; i++)
                        {
                            source.Add(i);
                        }
                    }
                    foreach (int i in source)
                        Console.Write(i);
