    public class Mon2Fri
    {
        public string StopNameMain { get; set; }
        public string StopNameSub { get; set; }
        public string StartingTime { get; set; }
    }
    
    public class Sat
    {
        public string StopNameMain { get; set; }
        public string StopNameSub { get; set; }
        public string StartingTime { get; set; }
    }
    
    public class Sun
    {
        public string StopNameMain { get; set; }
        public string StopNameSub { get; set; }
        public string StartingTime { get; set; }
    }
    
    public class A
    {
        public Mon2Fri[] Mon2Fri { get; set; }
        public Sat[] Sat { get; set; }
        public Sun[] Sun { get; set; }
    }
    
    public class Mon2Fri2
    {
        public string StopNameMain { get; set; }
        public string StopNameSub { get; set; }
        public string StartingTime { get; set; }
    }
    
    public class Sat2
    {
        public string StopNameMain { get; set; }
        public string StopNameSub { get; set; }
        public string StartingTime { get; set; }
    }
    
    public class Sun2
    {
        public string StopNameMain { get; set; }
        public string StopNameSub { get; set; }
        public string StartingTime { get; set; }
    }
    
    public class B
    {
        public Mon2Fri2[] Mon2Fri { get; set; }
        public Sat2[] Sat { get; set; }
        public Sun2[] Sun { get; set; }
    }
    
    public class RootObject
    {
        public A[] A { get; set; }
        public B[] B { get; set; }
    }
