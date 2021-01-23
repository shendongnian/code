    public enum AnimalType
    {
        Dog,
        Cat
    }
    public interface Animal
    {
        AnimalType animal { get; set; }
        string Name { get; set; }
    }
    
    public class Cat : Animal
    {
        public AnimalType animal { get; set; }
        public string Name { get; set; }
    
        public Cat()
        {
            animal = AnimalType.Cat;
        }
    }
    
    
    public class Dog : Animal
    {
        public AnimalType animal { get; set; }
        public string Name { get; set; }
    
        public Dog()
        {
            animal = AnimalType.Dog;
        }
    }
    
    public class MyViewModel
    {
        public List<Animal> MyAnimals { get; set; }
    
        public MyViewModel()
        {
            MyAnimals = new List<Animal>();
    
            var a = new Dog();
            var b = new Cat();
    
            MyAnimals.Add(a);
            MyAnimals.Add(b);
        }
    }
