    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Run() { }
    }
    public class Cat: Pet
    {
        public string Meow()
        {
            return "Meow";
        }
    }
    public class Dog :Pet
    {
        public string Bark()
        {
            return "Whow";
        }
    }
