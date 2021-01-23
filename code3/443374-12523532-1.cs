    if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
    {
        SetContentView(Resource.Layout.Main);
    }
    else
    {
        SetContentView(Resource.Layout.MainPortrait);
    }
