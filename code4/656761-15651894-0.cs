    namespace StackOverflow
    {
        public class Animal
        {
            public int Legs { get; set; }
            public string Color { get; set; }
            public string Origin { get; set; }
    
            public Animal() { Initialize(); }
            public virtual void Initialize() { Legs = 4; Color = "blue"; Origin = "everywhere"; }
        }
    
        public class Human : Animal
        {
            public Human() { }
            public override void Initialize() { Legs = 2; Color = "black"; Origin = "Africa"; }
        }
    
        public class Program
        {
            public static void main()
            {
                Animal a = new Animal();
                Animal h = new Human();
            }
        }
    }
