     class A {
        public bool IsAnimal { get; set; }
        public bool Found { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<A> lst = new List<A>();
            lst.Add(new A() { IsAnimal = false, Found = false });
            lst.Add(new A() { IsAnimal = true, Found = false  });
            lst.Add(new A() { IsAnimal = true, Found = false  });
            lst.Add(new A() { IsAnimal = false, Found = false  });
            // Here you first iterate to find only items with (IsAnimal == false)
            // then from IEnumerable we need to get a List of items subset
            // Last action is to execute ForEach on the subset where you can put your actions...
            lst.Where(x => x.IsAnimal == false).ToList().ForEach(y => y.Found = true);
        }
    }
