    public abstract class Animal {
        public abstract void Speak();
    }
    public class Dog : Animal {
        public override void Speak(){ Console.WriteLine("WOOF!! You're great."); }
    }
    public class Cat : Animal {
        public override void Speak(){ Console.WriteLine("Meow. Im better than you."); }
    }
    public class AnimalHandler {
        public virtual void Pet<T>(T animal) where T : Animal
        {
            animal.Speak();
        }
    }
