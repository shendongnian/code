                    int arrsize = Convert.ToInt32(Console.ReadLine());
                    int month = Convert.ToInt32(Console.ReadLine());//input from the user
                    List<int> source = new List<int>();
                    int temp = 0;
                    for (int i = 0; i < arrsize; i++)
                    {
                        temp = i + month;
                        if (temp != arrsize)
                            source.Add(((i + month) % arrsize));
                        else
                            source.Add(arrsize);
                    }
