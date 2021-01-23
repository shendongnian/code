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
    
                // Let's create an instance now
                var values = Enum.GetValues(myenum);
                var firstValue = values.GetValue(0);
                var enumInstance = Enum.Parse(myenum, firstValue.ToString());
    
                Console.WriteLine("I have an instance of the enum! {0}", enumInstance);
            }
        }
    }
