    public ItemTypeAttribute(string typeOf)
        : base(typeof(IItemInterface)) 
    {
        TypeOf = typeOf;
    }
