    public bool Equals(YourInterface one, YourInterface two)
    {
        return this.GetHashCode(one) == this.GetHashCode(two);
    }
         
    public int GetHashCode(YourInterface  test)
    {
        if(test == null)
        {
    
          return 0;
        }
        
         int hash = 0;
         //// get hash or set int on each property.
        
         return hash;
     }
