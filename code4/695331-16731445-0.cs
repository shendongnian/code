    listView.Adapter = new CustomAdapter(this, items);
    listView.ItemClick += OnListItemClick;
    protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
    {
        items[e.position] = Text2;
        listView.Adapter = new CustomAdapter(this, items);
    }
