        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            lvOnlineAdapter = new CustomAdapter(this, online);
            lvOnline = FindViewById<ListView>(Resource.Id.lvOnline);
            lvOnline.Adapter = lvOnlineAdapter;
            lvOnlineAdapter.Add("Test1");
            lvOnlineAdapter.Add("Test2");
            lvOnlineAdapter.Add("Test3");
            lvOnlineAdapter.EditItem(2, "test");
        }
    public void EditItem(int Position, string Text2)
    {
        items[Position] = Text2;
        NotifyDataSetChanged();
    }
