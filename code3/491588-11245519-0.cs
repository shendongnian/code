    public class A 
        {
            public int Id;
            public string Name;
            public string Hash;
            public C c;
        }
    
        public class B 
        {
            public int id;
            public string name;
            public C c;
        }
    
        public class C 
        {
            public string name;
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                var a = new A() { Id = 123, Name = "something", Hash = "somehash" };
                var b = new B();
    
                AutoMapper.Mapper.CreateMap<A, B>();
    
                b = AutoMapper.Mapper.Map<A, B>(a);
    
    
                Console.WriteLine(b.id);
                Console.WriteLine(b.name);
    
                Console.ReadLine();
            }
    }
