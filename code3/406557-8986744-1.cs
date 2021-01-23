    public class Animal
    {
        public string Name { get; set; }
        public Animal(string Name)
        {
            Name = name;
        }
    }
    
    public class Cat : Animal
    {
        public int Teeth { get; set; }
    
        public Cat(string name, int teeth)
        {
            Name = name; //<-- got from base
            Teeth = teeth; //<-- defined localy
        }
        //or do this
        public Cat(string name, int teeth) : base(name)
        {
            Teeth = teeth;
        }
    }
