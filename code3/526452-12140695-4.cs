    class Dog : Animal 
    { 
        public Dog() 
        { 
            legs = 4;
            Console.WriteLine("Dog constructor"); 
        } 
        
        public int legs { get; private set; }
        public void bark()
        {
             Console.WriteLine("grrrwoof!"); 
        }
    } 
