    public int Amount { get; set; }
    ...
    public void AddItem()
    {
        TransactionItem _item = new TransactionItem();
        // ...
       
        _item.Amount = Amount;
    }
