    class Animal
    {
        public Animal() 
        { 
            Console.WriteLine("Animal constructor"); 
        }
        public  void  show()        
        {
            Console.WriteLine("animal");
        }
    }
    class Dog : Animal 
    { 
        public Dog() 
        { 
            Console.WriteLine("Dog constructor"); 
        }
        public  void show()
        {
            Console.WriteLine("Dog");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Animal B = new Dog();
            B.show();
            Console.ReadKey();
        }
    }
