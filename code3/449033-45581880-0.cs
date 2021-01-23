    private static readonly LocalDataStoreSlot nameSlot = Thread.AllocateDataSlot();
    public string Name
    {
        get { return (string)Thread.GetData(nameSlot); }
        set { Thread.SetData(nameSlot, value); }
    }
