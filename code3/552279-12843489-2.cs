    public override bool Equals(object o)
    {
       if(o.GetType() != typeof(Car))
         return false;
         
       return (this.CarID == ((Car)o).CarID);
    }
    
    public override int GetHashCode()
    {
      return CarID.GetHashCode();
    }
