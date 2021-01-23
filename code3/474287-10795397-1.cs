    public void FillAList()
    {
        var list = new List<TEntity>();
        ProcessItems((index, item) => list.Add(item));
    }
