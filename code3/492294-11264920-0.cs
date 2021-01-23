    // modified example from docs, not tested
    class MyComparer : IEqualityComparer<Item>
    {
        // Items are equal if their ids are equal.
        public bool Equals(Item x, Item y)
        {
    
            // Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;
    
            // Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            //Check whether the items properties are equal.
            return x.ID == y.ID;
        }
    
        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.
    
        public int GetHashCode(Product product)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(item, null)) return 0;
    
            //Get hash code for the ID field.
            int hashProductId = product.ID.GetHashCode();
    
            return hashProductId;
        }
    
    }
    
    var myItems = (from b in this.result
                   select new Item{ Name = b.Name, ID = b.ID }).Distinct(new MyComparer());
