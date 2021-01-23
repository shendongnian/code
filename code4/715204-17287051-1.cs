    public IQueryable<ItemModel> GetAll()
    {
        return this.DataLayer.GetNewsItems()
           .Where(i => i.IsActive) 
           .Select((v,i) => new ItemModel(i));
    }
