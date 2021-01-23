    public override bool Equals(System.Object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        Facility objAsFacility = obj as Facility;
        return Equals(objAsFacility);
    }
    
    protected bool Equals(Facility other)
    {
        if (other.Fac_Name == this.Fac_Name)
            return true;
        else return false;
    }  
    public override int GetHashCode()
    {
        return this.Fac_Name.GetHashCode(); 
        //Or you might even want to this:
        //return (this.ID + this.Fac_Name).GetHashCode();
    }
