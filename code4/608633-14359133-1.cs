    public class YourClass
    {
        public string F1 {get; set;}
        public IEnumerable<MyType> F2 {get; set;}
    } 
    
    IEnumerable<YourClass> result
      = from A in As
        group A by A.F into B
        select new YourClass
        {
          F1 = B.Key,
          F2 = from A in As
               where A.F == B.Key
               select A
        };
