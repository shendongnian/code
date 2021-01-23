    private bool itemProcessed = false;
    private void ProcessListOfItems(List<string> items)
    { 
        while (items.Count > 0)
        {
            3rdPartyLibObject.Process(items[0]);
            if (itemProcessed)
            {
                items.Remove(0);
            }
        }
    }
    private void obj_ProcessingSuccess(object sender,    3rdPartyLibObject.ProcessingEventArgs e)
    {
        this.itemProcessed = true;
    }
    private void obj_ProcessingFailed(object sender, 3rdPartyLibObject.ProcessingEventArgs e)
    {
        this.itemProcessed = false;
    }
