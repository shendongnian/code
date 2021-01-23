    class Animal { 
       public void Speak() { Console.WriteLine("..."); }
    }
    class Dog : Animal { 
       remove void Speak();  // pretend you can do this
    }
    Animal a = GetAnAnimal(); // who knows what this does
    a.Speak();  // It's not known at compile time whether this is a Dog or not
