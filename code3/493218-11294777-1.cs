    private string _urlString;
    [DataMember]
    public string UrlPart
    {
        get { return _urlString;}
        set 
        {
            _urlPart = value;
            LoadImage(); // in this function you do the downloading stuff
        }
    }
    private BitmapImage _itemImage;
    public BitmapImage ItemImage
    {
        get {return _itemImage;}
        // you can also add a setter if needed
    }
