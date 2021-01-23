    aListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs args) 
      => ItemClicked(sender, args);
    public void ItemClicked(object sender, AdapterView.ItemClickEventArgs args)
    {
      try
      {
        String fName = ((TextView)args.View).Text;
        // Do something with clicked item text
      }
      catch (Exception) { throw; }
    }
