    class Program
    {
        static void Main(string[] args)
        {
            var myDemo = new Demo();
            myDemo.Size = 1000000;
    
            Console.WriteLine(myDemo.ToString(ConversionType.SizeInKb));
            Console.ReadKey();
        }
    
        enum ConversionType
        {
            SizeInKb
        }
    
        class Demo
        {
            public int? Size { get; set; }
    
            public string ToString(ConversionType convType)
            {
                switch (convType)
                {
                    case ConversionType.SizeInKb:
                        return Size.GetValueOrDefault() / 1000 + "Kb";
                    default:
                        return Size.GetValueOrDefault() + "bytes";
                }
            }
        }
    }
