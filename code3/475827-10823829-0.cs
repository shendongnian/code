    public class Animal
    {
        private readonly string _name;
        public Animal() : this("Animal") { }
        protected Animal(string name) { _name = name; }
        public void Speak() { Console.WriteLine(_name + " speaks"); }
    }
    public class NamedAnimal : Animal
    {
        public NamedAnimal(name) : base(name) { }
    }
    // usage:
    (new Animal()).Speak();  // prints "Animal speaks"
    (new NamedAnimal("Dog")).Speak();     // prints "Dog speaks"
