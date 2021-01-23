    public MainWindow() {
      InitializeComponent();
      var viewModel = new ViewModel();
      viewModel.Items.Add("Computer");
      viewModel.Items.Add("SetUp (D:)");
      viewModel.Items.Add("DELL Webcam");
      viewModel.Items.Add("Bitmaps");
      DataContext = viewModel;
    }
