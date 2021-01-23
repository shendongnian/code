    public int GetHashCode(Employee obj)
    {
         // null handling omitted for brevity, but you will want to
         // handle null values appropriately
         return obj.FirstName.GetHashCode() * 117 
              + obj.LastName.GetHashCode(); 
    }
