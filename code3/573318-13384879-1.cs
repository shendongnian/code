    static void Main(string[] args)
            {    
                string myInput;
                int myInt;
                string myInput2;
                int myInt2;
                int i;
    
                Console.Write("Please enter a number: ");
                myInput = Console.ReadLine();
                myInt = Int32.Parse(myInput);
    
                Console.Write("Please enter another number: ");
                myInput2 = Console.ReadLine();
                myInt2 = Int32.Parse(myInput2);
    
                i = myInt > myInt2 ? myInt2 : myInt;
                bool found = false;
                while(!found && i>0)
                {
                    if (myInt % i == 0 && myInt2 % i == 0)
                    {
                        Console.Write("Your GCF is...");
                        Console.Write("{0} ", i);
                        Console.ReadLine();
                        found = true;
                    }
                    else
                        i--;
                }
            }
