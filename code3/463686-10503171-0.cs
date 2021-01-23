    public MyBaseObject(MyBaseCollection<MyBaseObject> parent)
    {
        this.Parent = parent;
        parent.Add(new SomeOtherRealObject());
    }
