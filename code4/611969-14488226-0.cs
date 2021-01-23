    foreach (var item in selectedRowHandles)
    {
    	while (gridControl.GetRow(item) is NotLoadedObject)
    	{
                 Application.DoEvents();
    	 }
        SomeViewModel.SelectedItems.Add((SomeEntityObject)gridControl.GetRow(item)); 
    }
