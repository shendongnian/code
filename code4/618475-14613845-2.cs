    public override bool Equals(object other)
    {
        return Equals(other as MyType);
    }
    public bool Equals(MyType other)
    {
        if (ReferenceEquals(other, null))
        {
            return false;
        }
        // Now perform the equality check
    }
