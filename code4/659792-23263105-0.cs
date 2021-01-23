       bool flag = false;
    
    
                for (int n = 1;n < 101;n++)
                {
                    if (n == 1 || n == 2)
                    {
                        Console.WriteLine("prime");
                    }
    
                    else
                    {
                        for (int i = 2; i < n; i++)
                        {
                            if (n % i == 0)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
    
                    if (flag)
                    {
                        Console.WriteLine(n+" not prime");
                    }
                    else
                    {
                        Console.WriteLine(n + " prime");
                    }
                     flag = false;
                }
    
                Console.ReadLine();
