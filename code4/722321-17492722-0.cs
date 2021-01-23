     class Program
        {
            static void Main(string[] args)
            {
                var instance = MyEnum.First;
    
                if (instance == MyEnum.First)
                {
                    Console.WriteLine("== Called");
                }
    
                if (instance.Equals(MyEnum.First))
                {
                    Console.WriteLine("Equals called");
                }
               
            }     
        }
    
        enum MyEnum { First = 99, Second = 100}
