    public MainPage()
    {
        this.InitializeComponent();
        Init();
    }
    public async void Init()
    {
        await GetCredentials();
        await GetData();
    }
