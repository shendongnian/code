    protected bool Equals(Car other)
    {
        return CarID == other.CarID && string.Equals(CarName, other.CarName);
    }
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        var other = obj as Car;
        return other != null && Equals(other);
    }
    public override int GetHashCode()
    {
        unchecked
        {
            return (CarID.GetHashCode() * 397) ^ 
                    (CarName != null ? CarName.GetHashCode() : 0);
        }
    }
