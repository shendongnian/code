    public struct Attachment
    {
        private readonly Guid id;
        private readonly String name;
        public Guid Id { get { return id; } }
        public string Name { get { return name; } }
        public Attachment(Guid id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
