    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal sound");
        }
    }
    
    public class Dog:Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Dog sound");
        }
    }
        
    class Program
    {
        static void Main(string[] args)
        {
            Animal an = new Dog();
            an.MakeSound();           
            Console.ReadLine();
        }
    }
