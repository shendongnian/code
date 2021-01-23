    public override bool Equals(object obj)
    {
        Item item2 = obj as Item;
        if (item2 == null)
            return false;
        else
            return Equals(this, item2);
    }
    public override int GetHashCode()
    {
        return GetHashCode(this);
    }
