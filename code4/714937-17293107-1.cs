    private readonly MainViewModel _viewModel;
    public MainWindow()
    {
        InitializeComponent();
        webbrowser.LoadCompleted += new LoadCompletedEventHandler(webbrowser_LoadCompleted);
        _viewModel = DataContext as MainViewModel;
    }
    private void webbrowser_LoadCompleted(object sender, NavigationEventArgs e)
    {
            mshtml.HTMLDocument doc;
            doc = (mshtml.HTMLDocument)webbrowser.Document;
            mshtml.HTMLDocumentEvents2_Event iEvent;
            iEvent = (mshtml.HTMLDocumentEvents2_Event)doc;
            iEvent.onclick += new mshtml.HTMLDocumentEvents2_onclickEventHandler(ClickEventHandler);
    }
    private bool ClickEventHandler(mshtml.IHTMLEventObj pEvtObj)
    {
        _viewModel.HTMLObject = pEvtObj;
        return true;
    }
