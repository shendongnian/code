    class Program
    {
        static void Main(string[] args)
        {
            List<CustomClass> list = new List<CustomClass>() 
            {
                new CustomClass(){MyField = 3},
                new CustomClass(){MyField = 2},
                new CustomClass(){MyField = 1},
            };
    
            PrintList(list);
    
            list.Sort(new CustomClassComparer());
    
            PrintList(list);
    
            Console.ReadLine();
        }
    
        private static void PrintList(List<CustomClass> list)
        {
            foreach (var item in list)
            {
                if (item != null)
                    Console.WriteLine("MyField: {0}", item.MyField);
                else
                    Console.WriteLine("MyField: null");
            }
        }
    }
    
    public class CustomClass
    {
        public int MyField { get; set; }
    }
    
    public class CustomClassComparer : IComparer<CustomClass>
    {
        public int Compare(CustomClass x, CustomClass y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                return -1;
            }
    
            if (y == null)
                return 1;
    
            if (x.MyField == y.MyField)
                return 0;
    
            if (x.MyField == 2)
                return 1;
            if (x.MyField == 1)
                if (y.MyField == 3)
                    return 1;
                else
                    return -1;
    
            return -1;
        }
    }
