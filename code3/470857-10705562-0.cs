    public void MyForm_OnListViewDoubleClick(object sender, EventArgs e)
    {
       MoveListItem(firstListView, secondListView);
    }
    // ... 
    public static void MoveListItem(ListView source, ListView destination) 
    {
       var listItem = source.SelectedItem;
       source.Remove( listItem );
       destination.Add( listItem );
    }
