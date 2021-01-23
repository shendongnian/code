    public MyClass() {
        InitializeComponent();
        ViewModel = new MyViewModel();
        ViewModel.CurrentView = new DataGridChoice1();            
        this.DataContext = ViewModel;                      // <-- Added this line
    }
