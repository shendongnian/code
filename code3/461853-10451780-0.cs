    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Call
    {
        public int Id { get; set; }
        [ForeignKey("Receptor")]
        public int IdReceptor { get; set; }
        [ForeignKey("Required")]
        public int IdRequired { get; set; }
        public Person Receptor { get; set; }
        public Person Required { get; set; }
    }
