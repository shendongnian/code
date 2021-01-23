    public class NamedAnimal : Animal
    {
        public NamedAnimal(name) : base(name) { }
        public override Speak()
        {
            Console.Write("The animal named ");
            base.Speak();
        }
    }
    // usage:
    (new NamedAnimal("Dog")).Speak();  // Writes "The animal named Dog speaks"
