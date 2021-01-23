    class Topic
    {
        public int Id { get; set; }
        public int Drescription { get; set; }
        public Resource Resource { get; set; }
        public Topic()
        {
            Resource = new Resource();
        }
    }
