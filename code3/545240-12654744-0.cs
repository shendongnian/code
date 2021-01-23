    class Record
    {
        public int Id { get; private set; }
        public int ParentId { get; private set; }
        public string Name { get; private set; }
        public Record(int id, int parentId, string name)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
        }
    }
