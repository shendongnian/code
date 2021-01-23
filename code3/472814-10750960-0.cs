    public class Container<T> where T: Animal 
    {        
        public T Animal { get; set; } 
    }
    
    public class Animal
    {
    }
    public class Dog : Animal
    {
        public void Speak() { Console.WriteLine("Woof!"); }
        public string Name { get; set; }
    }
    var c = new Container<Dog> { Animal = new Dog() { Name = "dog1" } };
    var json = JsonSerializer.SerializeToString<Container<Dog>>(c);
    var c2 = JsonSerializer.DeserializeFromString<Container<Dog>>(json);
    c.Animal.Speak(); //Works
    c2.Animal.Speak(); 
