    public interface IAnimal
    {
        string Speak();
    }
    public class Dog : IAnimal
    {
        public string Speak()
        {
            return "Woof, woof";
        }
    } 
    public class Cat : IAnimal
    {
        public string Speak()
        {
            return "Meow";
        }
    } 
    public class Parrot : IAnimal
    {
        public string Speak()
        {
            return "Sqwark!";
        }
    } 
