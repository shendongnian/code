    class Program
    {
        class A 
        {
            public Guid ID { get; set; }
    
            public A Clone()
            {
                return (A)this.MemberwiseClone();
            }
        }
    
        static void Main(string[] args)
        {
            var item1 = new A();
            item1.ID = Guid.NewGuid();
    
            var item2 = item1.Clone();
            item2.ID = Guid.NewGuid();
    
            Console.WriteLine(item1.ID);
            Console.WriteLine(item2.ID);
    
            Console.ReadKey();
        }
    }
