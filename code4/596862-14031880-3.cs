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
        r.Row.Delete();
        removedCount++;
    }
