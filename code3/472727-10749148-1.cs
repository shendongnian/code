    // step 1. find the items to be removed
    
    //items to be removed will be added to this list
    var itemsToRemove = new List<DataGridViewRow>(); 
    foreach (DataGridViewRow r in dgv01.Rows)
    {
        if (r.Cells[0].Value.ToString() == "abc")
        {
            itemsToRemove.Add(r);
        }
    }
    //step 2. remove the items from the DataGridView
    foreach (var r in itemsToRemove)
    {
        // this works because we're not iterating over the DataGridView.
        dgv01.Rows.Remove(r);
    }
