    public MyFunction(IEnumerable<IDataHolder> columns)
    {
        //replace c.DeepCopy() with whatever the deep copying function is
        this.columns = columns.ToDictionary(c => c.info.name, c => c.DeepCopy());
    }
