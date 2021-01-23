    public class MyObject
    {
       public string Name { get; set; }
       public string Something1{ get; set; }
       public string Something2{ get; set; }
       public string Something3 { get; set; }
       [ScriptIgnore()]
       public MyObjectMyObject2 { get; set; }
    
       public string Color { get { return this.MyObject2.Color; } }
       public string Something4 { get { return this.MyObject2.Something4; } }
    }
    
    public class MyObject2
    {
        public string Color { get; set; }
        public string Something4 { get; set; }
    }
