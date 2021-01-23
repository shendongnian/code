    class Professor
    {
        public Professor()
        {
             Classes = new List<Class>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Class> Classes {get; set;}
    }
