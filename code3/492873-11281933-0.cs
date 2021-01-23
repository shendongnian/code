    int index = -1;
    IEnumerable<dictSearchResults> sResults = (IEnumerable<dictSearchResults>)lstGoto.DataContext;
    //Makin a list of all the DisplayIndex from the IEnumerable object
    var lstGotoResults= sResults.Select(rec => rec.DisplayIndexForSearchListBox.ToString()).ToList();
    index = await TaskEx.Run(() =>
    {
        return lstGotoResults.IndexOf(ayaIndexStr);
    });
    if (index >= 0)
    { 
        lstGoto.SelectedIndex = index ;
        lstGoto_SelectionChanged(lstReadingSearchResults, null);
        stkPanelGoto.Visibility = Visibility.Collapsed;
    }
