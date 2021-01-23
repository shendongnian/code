    public IEnumerable<ItemModel> GetItemsByDate(Expression<Func<ItemModel,bool>> filter)
    {
        return this.DataLayer.GetNewsItems()
           .Where(i => i.IsActive && filter)
           .AsEnumerable()
           .Select(x => new ItemModel(x));
    }
