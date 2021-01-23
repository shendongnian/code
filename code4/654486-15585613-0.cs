    public abstract class Animal
    {
        public Animal(string name)
        {
            this.Name = name;
        }
        public string Name 
        { 
            get; 
            private set; 
        }
    }
    public class Cat : Animal
    {
        public Cat(string name)
            : base(name)
        {
        }
            
        string NoOfLegs { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Animal aCat = new Cat("a");
        }
    }
