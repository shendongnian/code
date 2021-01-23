    public Uri IconUri
        {
            get { return (Uri)GetValue(IconUriProperty); }
            set { SetValue(IconUriProperty, value); }
        }
    // Using a DependencyProperty as the backing store for IconUri.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconUriProperty =
        DependencyProperty.Register(
            "IconUri",
            typeof(Uri),
            typeof(ApplicationBarIconButton),
            new PropertyMetadata(default(Uri), (d, e) => ((ApplicationBarIconButton)d).IconUriChanged((Uri)e.NewValue)));
    private void IconUriChanged(Uri iconUri)
    {
        var button = SysAppBarMenuItem as Microsoft.Phone.Shell.IApplicationBarIconButton;
        button.IconUri = iconUri;
    }
