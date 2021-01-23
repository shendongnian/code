    class Program
    {
        static List<Bag> bags = new List<Bag>();
        static List<Lunch> lunches = new List<Lunch>();
        
        static void Main(string[] args)
        {
            lunches.Add(new Lunch() { Num = 1 });
            lunches.Add(new Lunch() { Num = 2 });
            lunches.Add(new Lunch() { Num = 3 });
            bags.Add(new Bag() { Num = 1 });
            bags.Add(new Bag() { Num = 2 });
            int count = 0;
            while (count < Math.Pow(lunches.Count, bags.Count))
            {
                Console.WriteLine("Permutation " + count);
                string countNumber = ConvertToBase(count, lunches.Count).PadLeft(bags.Count,'0');
                for (int x = 0; x < bags.Count; x++)
                {
                    Console.WriteLine(bags[x] + " " + lunches[Convert.ToInt32((""+countNumber[x]))]);
                }
                Console.WriteLine("");
                count++;
            }
            Console.ReadLine();
        }
        static string ConvertToBase(int value, int toBase)
        {
            if (toBase < 2 || toBase > 36) throw new ArgumentException("toBase");
            if (value < 0) throw new ArgumentException("value");
            if (value == 0) return "0"; //0 would skip while loop
            string AlphaCodes = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string retVal = "";
            while (value > 0)
            {
                retVal = AlphaCodes[value % toBase] + retVal;
                value /= toBase;
            }
            return retVal;
        }
    }
    class Lunch
    {
        public int Num { get;set;}
        public override string  ToString()
        {
 	         return "Lunch " + Num;
        }
    }
    class Bag
    {
        public int Num { get;set;}   
        
        public override string  ToString()
        {
 	         return "Bag " + Num;
        }
    }
