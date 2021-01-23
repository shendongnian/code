                            bool isPrime = true;
                            for (p = 2; p <= Math.Sqrt(i); p++)
                                if (i % p == 0)
                                {
                                    isPrime = false;
                                    break;
                                }
                                if (isPrime)
                                {
                                    Console.Write("{0} ", i);
                                    Console.ReadLine();
                                }
