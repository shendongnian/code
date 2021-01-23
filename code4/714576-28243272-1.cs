        public class SourceEntity 
        {
             public string MyField {get; set;}         
  
             public override bool Equals(object obj)
             {
                  return true;
             }
        }
        public class TargetEntity 
        {
              public string MyField {get; set;}  
        }
