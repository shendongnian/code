    public ScoreBoard()
    {
        InitializeComponent();
        DataSet ds = dweMethods.DecryptAndDeserialize("ScoreData.xml")
        XElement TrackList = XElement.Parse(ds.GetXml());
        LibraryView.DataContext = TrackList;
    }
