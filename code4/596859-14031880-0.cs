    int count=theDataGrid.SelectedItems.Count;
    int removedCount=0; 
    int index=-1; 
    while (removedCount < count)
    {
        index++;
        Object o = theDataGrid.SelectedItems[index];
        if (o != CollectionView.NewItemPlaceholder)
        {
            DataRowView r = (DataRowView)o;
            int k = ds.Tables["producer"].Rows.IndexOf(r.Row);
            ds.Tables[0].Rows[k].Delete();
            removedCount++;
        }
    }
