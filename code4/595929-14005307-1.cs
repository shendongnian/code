    private void RemoveItemExcecute(object param)
    {
        // "param" is the command parameter passed to the command.
        MyItem item = (MyItem)param;
        MyItemCollection.Remove(item);
    }
