    public class Animal
    {
        public virtual void Process()
        {
            Console.WriteLine("Animal (not a dog)");
        }
    }
    public class Dog : Animal
    {
        public override void Process()
        {
            Console.WriteLine("We have a dog");
        }
    }
