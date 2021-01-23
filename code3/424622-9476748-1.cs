    public void myfun()
            {
                string inValue;
                int first;
                int second;
                int sum;
    
                do
                {
                    Console.Write("\nEnter the first number. (Type \"xxx\" to exit):   ");
                    inValue = Console.ReadLine();
    
                    if (int.TryParse(inValue, out first))
                    {
                       // first = Convert.ToInt32(inValue);   //@@@@@
                        Console.Write("\nEnter the second number. (Type \"xxx\" to exit):   ");
                        inValue = Console.ReadLine();
                        if(int.TryParse(inValue, out second))
                        {
                       // second = int.Parse(inValue);
    
                        sum = first + second;
    
                        Console.WriteLine("\nThe sum of {0} and {1} is {2}.", first,
                            second, sum);
                        }
                    }
                    /* Things I've tried inside do { } and that don't work */
    
                    //inValue = "";
                    //inValue = null;
                    //inValue = inValue.ToString();
                    //inValue = first.ToString();
                    //inValue = second.ToString();
                }
    
                while (inValue != "xxx");   /*If you enter a non-numeric string,
                                         * an exception is thrown at
                                         * @@@@@ above.
                                         */
    
                Console.ReadLine();
            }
