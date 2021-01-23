    public ClientReceiptView(string Header)
    {
        InitializeComponent();
        vm = new ClientReceiptViewModel();
        this.DataContext = vm;
        vm.SetHeader(Header);
    }
