    public class ComplexType      
    {      
       public String Name { get; set; }      
       public String FormattedName { get; set; }      
       public String Description { get; set; } 
       public override string ToString()
       {
          return this.Name;
       }     
    }  
 
