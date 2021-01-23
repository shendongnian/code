    abstract class Field {
         public string Name {get;set; }
    }
    
    class BooleanField : Field{
         public bool Value { get;set; }
    }
    
    class TextField : Field{
          public string ValidationRegEx { get; set }
          public string Value { get;set; }
    }
