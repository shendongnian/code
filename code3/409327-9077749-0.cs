    public static bool operator !=(MyType first, MyType second)
    {
        return !(first == second);
    }
    public static bool operator ==(MyType first, MyType second)
    {
        if (ReferenceEquals(first, null)
           || ReferenceEquals(second, null))
        {
            return ReferenceEquals(first, second);
        }
        return first.Equals(second);
    }
    public override bool Equals(object obj)
    {
        return Equals(obj as MyType);
    }
    public bool Equals(MyType other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        if (ReferenceEquals(this, other))
        {
            return true;
        }
        // Check all simple properties
        if (GetHashCode() != other.GetHashCode()
            || Name != other.Name
            || Age != other.Age
            || Phone != other.Phone)
        {
            return false;
        }
        return true;
    }
    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 34591;
            if (Name != null)
            {
                hash = hash * 29863 + Name.GetHashCode();
            }
            if (Phone != null)
            {
                hash = hash * 29863 + Phone.GetHashCode();
            }
            hash = hash * 29863 + Age;
            return hash;
        }
     }
