    using System;
    using System.Linq;
    
    class Test
    {
        public string Foo { get; set; }    
        public int Bar { get; set; }
        
        public void DumpProperties()
        {
            this.GetType().GetProperties().ToList()
                .ForEach(p => Console.WriteLine("{0}: {1}", p.Name,
                                                p.GetValue(this, null)));
        }
        
        static void Main()
        {
            new Test { Foo = "Hi", Bar = 20 }.DumpProperties();
        }
    }
