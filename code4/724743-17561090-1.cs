    public class Person
    {
        [StringLength(MaximumLength=1000)]
        public string Name { get; set; }
    	
    	public string OtherName { get; set; }
    }
