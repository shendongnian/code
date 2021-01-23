    class Program
    {
        //variable with the Values
        List<string> RandomVal = new List<string>();
        //variable to compare the randomly genarated Values
        List<string> CompaerbyString = new List<string>();
        //Variable that gets Value from  the list Values
        string DisplayVal;
        //instantiates the Random Class
        Random r;
        //this Method gives Value to the list and initializes th the Random Class
        void setVal()
        {
            //Adding to the list
            RandomVal.Add("A");
            RandomVal.Add("b");
            RandomVal.Add("c");
            RandomVal.Add("d");
            RandomVal.Add("e");
            RandomVal.Add("f");
            RandomVal.Add("g");
            RandomVal.Add("h");
            RandomVal.Add("i");
            RandomVal.Add("j");
            RandomVal.Add("k");
            RandomVal.Add("l");
            RandomVal.Add("m");
            RandomVal.Add("n");
            RandomVal.Add("o");
            RandomVal.Add("p");
            RandomVal.Add("q");
            RandomVal.Add("r");
            RandomVal.Add("s");
            RandomVal.Add("t");
            RandomVal.Add("u");
            RandomVal.Add("v");
            RandomVal.Add("w");
            RandomVal.Add("x");
            RandomVal.Add("y");
            RandomVal.Add("z");
      
            //Instantiating the Random Method
            r = new Random();
        }
        //This method Gives Out the Random Values
        public void DisplayRand()
        {
                  
           //Setting Random Index 
           int getIndex =  r.Next(0, RandomVal.Count - 1);
            //Now we are trying to pass a random value to the String 
            DisplayVal = RandomVal.ElementAt<string>(getIndex);
            //we are testing to see if String in Display is contained in the List that will used Compare
            if (!CompaerbyString.Contains(DisplayVal))
                Console.WriteLine(DisplayVal.ToUpper());
            else
            {
                try
                {
                    this.DisplayRand();
                }
                catch(Exception e)
                {
                    Console.WriteLine("You have Reached the End of the list...");
                    Environment.Exit(0);
                }
            }
            //Adding Corrent DisplayVal's Value to the List for Comparison
            CompaerbyString.Add(DisplayVal);
        }
        //This is Simple method that Calls the Display
        void Call()
        {
            //This For loop is to Ensure we have no Stack Overflow
            for ( int i = 0; i < RandomVal.Count-1;i++)
            {
                this.DisplayRand();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Random Values With Out Repeatating Any Value");
            //Simple Instantiation
            Program dis = new Program();
            //Simple Call
            dis.setVal();
            //Simple Call
            dis.Call() ;
            Console.ReadLine();   
        }
    }
