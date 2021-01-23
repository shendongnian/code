    namespace StackOverflow
    {
        public class Animal
        {
            public int Legs { get; set; }
            public Animal() { Legs = 4;  }
            public Animal(int legs) { Legs = legs; }
        }
        public class Human : Animal
        {
            public Human() : base(2) { }
        }
    }
