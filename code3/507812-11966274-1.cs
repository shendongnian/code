        public class Planet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        ...
        public List<Building> Constructions { get; set; } 
    }
    public class Building
    {
        [Key]
        public int Id { get; set; }
        public decimal Lvl { get; set; }
        public string Type { get; set; }
        //Add these two properties to create the Foreign Key Association
        public int planetID { get; set; }
        public Planet planet { get; set; }
    }
