    public override bool Equals(object obj)
    {
       var i = obj as YourType;
       if(i == null) return false;
    
       return i.Id == this.Id && i.Name == this.Name;
    }
    
    public override int GetHashCode()
    {
       return this.Id.GetHashCode() ^ this.Name.GetHashCode();
    }
