    public class X
    {
        [Key]
        public int ID { get; set; }
    	public int line {get; set;}
    	
        public virtual Y Y { get; set; }
    }
    
    public class Y
    {
        [Key]
        public int ID { get; set; }
    	public int line {get; set;}
    	
        public virtual X X { get; set; }
    }
