    public class Object1
    {
        [Key]
        public int Object1ID { get; set; }
        .....
        public int Object2ID { get; set; }
        public List<Object2> listObject2 { get; set; }
    }
    public class Object2
    {
        [Key]
        public int Object2ID { get; set; }
	.....
	public int Object1ID { get; set; }
        public Object2 myObject2 { get; set; }
    }
