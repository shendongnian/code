    public abstract class Car { 
        internal string Type {get; protected set;} //Compact, Medium, Large, ... 
        public string Name {get; set; }  //Model name 
    } 
    
    public class CompactCar : Car
    {
         public CompactCar() { this.Type = "Compact"; }
    }
    
    public class MediumCar : Car
    {
         public MediumCar() { this.Type = "Compact"; }
    }
