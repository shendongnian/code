    public int GetHashCode(Employee obj)
    {
         return obj.FirstName.GetHashCode() * 117 
              + obj.LastName.GetHashCode(); 
    }
