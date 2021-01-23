    private async void btnAddItem_Click(object sender, EventArgs e)
    {
        var item = new workUnit();
        // TODO: Add item on UI here
        try
        {
            await myClass.EnQueue(item);
 
            // TODO: Update UI with success result here (no context synchronisation is needed here it is already in the UI context)
        }
        catch
        {
            // TODO: Update UI with error result here (no context synchronisation is needed here it is already in the UI context)
        }
    }
    
