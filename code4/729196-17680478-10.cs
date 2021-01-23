    // on Form2
    public event EventHandler<ItemDeletedEventArgs> ItemDeleted;
    public Form2(List<Item> items)
    {
       ...
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
        // delete item from db
        OnItemDeleted(itemId)
    }
    protected void OnItemDeleted(int itemId)
    {
       if (ItemDeleted == null)
           return;
       ItemDeleted(this, new ItemDeletedEventArgs(itemId));
    }
