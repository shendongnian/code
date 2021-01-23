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
            for( int i = 0; i < myLayout.getChildCount(); i++ )
                if( myLayout.getChildAt( i ) instanceof TextView )
                {
                    TextView tvBold = (TextView) myLayout.getChildAt( i );
                    if(tvBold.getText().ToString() == "test")
                        tvBold.SetBackgroundColor(Color.Yellow);
                }
        }
    public void EditItem(int Position, string Text2)
    {
        items[Position] = Text2;
        NotifyDataSetChanged();
    }
