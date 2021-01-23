        EventSetter ev = new EventSetter();
        ev.Event = ListViewItem.PreviewMouseUpEvent;
        ev.Handler = new MouseButtonEventHandler(itemClicked);
        Style myStyle = new Style();
        myStyle.TargetType = typeof(ListViewItem);
        myStyle.Setters.Add(ev);
        
        listView.ItemContainerStyle = myStyle;
....
    void itemClicked(object sender, MouseButtonEventArgs e)
    {
         // item was licked in listview implement behavior in here
    }
