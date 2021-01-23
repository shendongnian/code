    public View Item(int productNumber)
    {
        var parameters = new GetItemByProductNumberParameters
        {
            ProductNumber = productNumber,
            // other parameters here
        };
        Item item = this.getItemQuery.Handle(parameters);
        return this.View(item);
    }
