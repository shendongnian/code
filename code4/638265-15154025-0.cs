    public class School
    {
        public int ID { get; set; }
        public string SchoolName { get; set; }
        public ICollection<Section> Sections { get; set; }
        public Section()
        {
            Sections = new List<Section>();
        }
    }
