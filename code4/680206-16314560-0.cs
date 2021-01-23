    public sealed class Category
    {
        private readonly int id;
        public int Id { get { return id; } }
        private readonly string description;
        public string Description { get { return description; } }
        public Category(int id, string description)
        {
            this.id = id;
            this.description = description;
        }
        // Possibly override Equals etc
    }
