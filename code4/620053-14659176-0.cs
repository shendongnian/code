    //Here sender is your list view
    public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e)
    {
       ListView lv = sender as ListView;
       Segment seg = e.ClickedItem as Segment;
    
       if (lv != null)
       {
          //Use your lv if you want to
       }
    
       if (seg != null)
       {
          string name = seg. SegmentName;
       }
    }
