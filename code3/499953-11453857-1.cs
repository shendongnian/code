    public class SomeClass : ISomeInterface
    {
       private readonly string p1;
       private string p2;
       private ISomeConfiguration config;
    
       public SomeClass(ISomeConfiguration config)
       {
           this.config = config;
       }
    
       public string Prop1 { get { return config.SomeSetting; } }
       public string Prop2
       {
           get
           {
              switch(Prop1)
              {
                  case "setting1": return "one";
                  case "setting2": return "two";
                  case "setting3": return "three";
                  default: return "one";
              }
           }
           set { p2 = value; }
      }
