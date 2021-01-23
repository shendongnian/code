        class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine(false.AllEqual(false, false)); 
                    Console.WriteLine(true.AllEqual(false, false));
                    Console.WriteLine(true.AllEqual(true, false));
                    bool a = true;
                    bool b = false;
                    bool c = true;
                    Console.WriteLine(a.AllEqual(b, c));
                    b = true;
                    Console.WriteLine(a.AllEqual(b, c));
                    Console.ReadLine();
                } 
            }
        
            static class Extensions
        {
            static public  bool AllEqual(this bool firstValue, params bool[] bools)
            {
                return bools.All(thisBool => thisBool == firstValue);
            }
        }
