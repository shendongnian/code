    public class Animal
    {
        public string Name { get; set; }
        public string Speak()
        {
            return "Animal Speak";
        }
        public string Hungry()
        {
            return this.Speak();
        }
    }
    public class Dog : Animal
    {
        public new string Speak()
        {
            return "Dog Speak";
        }
        public string Fetch()
        {
            return "Fetch";
        }
    }
    static void Main(string[] args)
    {
        Animal a = new Dog();
        Console.WriteLine(a.Hungry());   //Animal Speak
        Console.ReadLine();
    }
