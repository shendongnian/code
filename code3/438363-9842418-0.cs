    public UpdateStatus(Guid id, string status) 
    { 
        var item = ItemList1.FirstOrDefault(s => s.Id == id)
            ?? ItemList2.FirstOrDefault(s => s.Id == id)
            ?? ItemList3.FirstOrDefault(s => s.Id == id)
        if (item == null) 
        { 
            Debug.WriteLine("Unable to update Status"); 
            return; 
        } 
        item.UpdateStatus(status); 
    } 
