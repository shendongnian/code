    int count=theDataGrid.SelectedItems.Count;
    int removedCount=0; 
    while (removedCount < count)
    {
        try{
             Object o = theDataGrid.SelectedItems[0];
        }
        catch{ break;}
        if (o == CollectionView.NewItemPlaceholder)
        continue;
        DataRowView r = (DataRowView)o;
        int k = ds.Tables["producer"].Rows.IndexOf(r.Row);
        ds.Tables[0].Rows[k].Delete();
        removedCount++;
    }
