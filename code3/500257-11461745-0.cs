    using System;
    public class Base  // I cannot change this class
    {
        public string Something { get; set; }
        public string Otherthing { get; set; }
        public static Base StaticPreSet
        {
            get { return new Base { Something = "Some", Otherthing = "Other"}; }
        }
    
        public static Base StaticPreSet2
        {
            get { return new Base { Something = "Some 2", Otherthing = "Other 2"}; }
        }
    }
    public class SubClass : Base  // I can change this class all I want.
    {
        public string MoreData { get; set; }
        public static SubClass StaticPreSet2
        { 
            get { return new SubClass { Something = "inherited", Otherthing=""}; }
        }
    }
    public class Test
    {
    	public static void Main()
        {
	    Console.WriteLine(SubClass.StaticPreSet2.Something);
       	}
    }
