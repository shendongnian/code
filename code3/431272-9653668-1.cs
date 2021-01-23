    public class Config : IComparable
    {
       public string Name { get; set; }
    
       // other properties
       
       public int CompareTo(object obj) {
            if (obj == null) return 1;
    
            Config otherConfig = obj as Config;
            if (otherConfig != null) 
                
                // this is where you would place the compare logic
                
            else
               throw new ArgumentException("Object is not a Config");
        }
    }
