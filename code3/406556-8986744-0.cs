    public class Animal
    {
        public string Name { get; set; }
    }
    
    public class Cat : Animal
    {
        public int Teeth { get; set; }
    
        public Cat(string name, int teeth)
        {
            Name = name; //<-- got from base
            Teeth = teeth; //<-- defined localy
        }
    }
