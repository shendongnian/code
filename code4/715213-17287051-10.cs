    public IEnumerable<ItemModel> GetItemsByDate(DateTime date)
    {
        return this.DataLayer.GetNewsItems()
           .Where(i => i.IsActive && i.Date == date)
           .AsEnumerable()
           .Select(x => new ItemModel(x));
    }
