     System.Random generator = new Random(DateTime.Now.Millisecond);
                int[] lotteryNumber = new int[7];
                int lowerBounds = 1;
                int upperBounds = 8;
                int maxNumberLotteryValues = 7;
    
                if ( ( upperBounds - lowerBounds ) < (maxNumberLotteryValues))
                {
                    Console.Write("Warning: Adjust your upper and lower bounds...there are not enough values to create a unique set of Lottery numbers! ");
    
                }
                else
                {
                    Console.WriteLine("Your lottery numbers: ");
                    for (int i = 0; i < maxNumberLotteryValues; i++)
                    {
                        int nextNumber = generator.Next(lowerBounds, upperBounds);
                        int count = lowerBounds;  //Prevent infinite loop
    
                        while ((lotteryNumber.Contains(nextNumber))
                            && (count <= upperBounds))
                        {
                            nextNumber = generator.Next(lowerBounds, upperBounds);
                            count++;  //Prevent infinite loop
                        }
    
                        lotteryNumber[i] = nextNumber;
                        Console.Write("{0} ", lotteryNumber[i]);
                    }
                }
               
                Console.ReadLine();
