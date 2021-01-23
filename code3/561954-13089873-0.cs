    protected override void OnCreate(Bundle bundle)
    {
        ...
        Intent i = GetIntent();
        itemsList.Text = i.GetStringExtra("TheItem");
    }
