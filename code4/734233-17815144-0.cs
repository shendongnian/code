    // animal classes
    public class Animal
    {
        public String Name { get; set; }
        public Animal() : this("Unknown") {}
        public Animal(String name) { this.Name = name; }
    }
    public class Dog : Animal
    {
        public Dog() { this.Name = "Dog"; }
    }
    public class Cat : Animal
    {
        public Cat() { this.Name = "Cat"; }
    }
    
    // animal collection
    public class Animals : Collection<Animal>
    {
        
    }
    
