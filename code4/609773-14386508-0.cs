    public override Int32 GetHashCode()
    {
        // If this.Key may be null you have to handle this case.
        return this.Key.HashCode();
    }
    public override Boolean Equals(Object obj)
    {
        var other = obj as A;
        return (other != null) && (this.Key == other.Key);
    }
