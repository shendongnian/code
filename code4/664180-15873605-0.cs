    private List<MyModel> _myItems;
    public IList<MyModel> MyItems
    {
        get
        {
            if (_myItems == null)
            {
                myItems = new List<MyModel>();
                myItems.Add(new MyModel() { Name = "A" });
                myItems.Add(new MyModel() { Name = "B" });
                myItems.Add(new MyModel() { Name = "C" });
            }
            return _myItems}
        }
    }
