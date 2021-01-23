    public class Animal
    {
        public string Name { get; set; }
    }
    
    public class Cat : Animal
    {
        public int Teeth { get; set; }
    
        public Cat(string name, int teeth) : Base(name) //pass name to base constructor
        {
            Teeth = teeth;
        }
    }
