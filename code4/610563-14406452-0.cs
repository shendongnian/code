    public class Animal
    {
        public string Name { get; set; }
    
        public virtual string Speak()
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
        public override string Speak()
        {
            return "Dog Speak";
        }
    
        public string Fetch()
        {
            return "Fetch";
        }
    }
    public class Cat: Animal
    {
        public override string Speak()
        {
            return "Cat Speak";
        }
    
        public string Fetch()
        {
            return "Fetch";
        }
    }
