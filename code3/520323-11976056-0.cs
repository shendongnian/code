    namespace enumtest
    {
        public enum Mine
        {
            data1,
            data2
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Type myenum = Type.GetType("enumtest.Mine");
    
                foreach (var curr in Enum.GetValues(myenum))
                {
                    Console.WriteLine(curr.ToString());
                }
            }
        }
    }
