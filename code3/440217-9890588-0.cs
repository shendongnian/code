    class Mammal {
        public readonly Action Foo;
    
        public Mammal(Action foo) { Foo = foo;}
    }
    ...
    ...
    var MyMammal = new Mammal(() => {Console.WriteLine("Wooo");});
