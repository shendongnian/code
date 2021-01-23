    public class Toy
    {
        public Person Owner { get; set; }
        public Toy(string toyName);
    }
    public class Person
    {
        Int16 id;
        string name;
        List<Toy> toys;
        public Person(Int16 id, string name, List<Toy> toys)
        { 
            this.id = id;
            this.name = name;
            this.toys = new List<Toy>();
            this.AddToys(toys);
        }
        private void AddToys(List<Toy> toys)
        {
            foreach (var toy in toys)
            {
                this.toys.Add(toy);
                toy.Owner = this;
            }
        }
    }
