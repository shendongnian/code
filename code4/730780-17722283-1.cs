    class a
    {
        public virtual void Info()
        {
            Console.WriteLine("I'm a");
        }
    }
    
    class b : a
    {
        public override void Info()
        {
            Console.WriteLine("I'm b");
        }
    }
