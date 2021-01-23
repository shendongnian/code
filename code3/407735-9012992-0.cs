    public override bool Equals(object o)
    {
        MyItems mi = o as MyItems;
        if (mi == null)
            return false;
        if (itemName == null)
            return mi.itemName == null;
        return itemName.Equals(mi.itemName);
    }
    public override int HashCode()
    {
        return (itemName ?? string.Empty).HashCode();
    }
