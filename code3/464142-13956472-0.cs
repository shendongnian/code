    foreach (var item in GridView_ButtonsQuest.Items)
    {
    	var gridItem = (GridViewItem)MyList.ItemContainerGenerator.ContainerFromItem(item);
    	var wrap1 =VisualTreeHelper.GetChild(gridItem , 0);
        var wrap2 = VisualTreeHelper.GetChild(wrap1 , 0);
       ...
