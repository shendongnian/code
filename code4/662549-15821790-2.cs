    public override bool Equals(object obj)
    {
        var other = obj as Amenity;
        if(other == null)
        {
            return false;
        }
        
        return Id = other.Id && Name == other.Name && Category == other.Category;
    }
    
    public override int GetHashCode()
    {
        return Id.GetHashCode(); //assumes Id is immutable
    }
