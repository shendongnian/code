    public class Item
    {
        public int Id { get; }
        public string Name { get; }
        public Item(string name, int id)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
