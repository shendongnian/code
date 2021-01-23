    public class Car : IEquatable<Car>
    { 
        ...    
        public override bool Equals(object o)
        {
           if(o.GetType() != typeof(Car))
             return false;
             
           return this.Equals((Car)o);
        }
        
        public override int GetHashCode()
        {
          return CarID.GetHashCode();
        }
    
        public bool Equals(Car o)
        {
             return (this.CarID == o.CarID); 
        }
    } 
