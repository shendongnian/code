    class Person 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
    class Phone
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
