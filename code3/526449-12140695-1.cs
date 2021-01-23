    class Dog : Animal 
    { 
        public Dog() 
        { 
            legs = 4;
            Console.WriteLine("Dog constructor"); 
        } 
        
        public int legs { get; set; }
        public void bark()
        {
             Console.WriteLine("grrrwoof!"); 
        }
    } 
