    Dispatcher.BeginInvoke(() =>
    {
        var Selecteditem = listmy.Items[listmy.Items.Count - 1];
        listmy.ScrollIntoView(Selecteditem);
        listmy.UpdateLayout(); 
    });
