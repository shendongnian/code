    public MainWindow()
    {
        var uploaderViewModel = new UploaderViewModel(ObjectFactory.GetInstance<IVEDocumentService>());
        this.Resources["UploaderViewModel"] = uploaderViewModel;
        InitializeComponent();
    }
