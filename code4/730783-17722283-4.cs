    class a
    {
        public void Info()
        {
            Console.WriteLine("I'm a");
        }
    }
    
    class b : a
    {
        public new void Info()
        {
            Console.WriteLine("I'm b");
        }
    }
