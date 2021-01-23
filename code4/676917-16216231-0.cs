    public class Animal
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; private set; }
        public Animal() { }
        public Animal(string type)
        {
            AnimalType = type;
        }
        // to denie self repeading if all animales have the same Properties
        protected void set(Animal a)
        {
            Id = a.Id;
            Name = a.Name;
            AnimalType = a.AnimalType;
        }
    }
.
    Dog doesnt have any more parameters than Animal has, only new methods
