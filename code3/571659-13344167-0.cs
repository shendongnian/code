    public class Entity1
    {
        public int Id { get; set; }
    }
    
    public class Entity2
    {
        public int Id { get; set; }
    }
    
    public class Many2ManyRelationEntity
    {
        public int Id { get; set; }
        public int? Entity1Id { get; set; }
        public int? Entity2Id { get; set; }
    }
