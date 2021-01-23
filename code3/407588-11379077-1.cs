    ResultsListView.BeginUpdate();
    ResultsListView.ListViewItemSorter = null;
    ResultsListView.Items.Clear();
    
    //here we add items to listview
    
    //adding item sorter back
    ResultsListView.ListViewItemSorter = lvwColumnSorter;
    
    
    ResultsListView.Sort();
    ResultsListView.EndUpdate();
