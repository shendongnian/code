    public Form1() {
      InitializeComponent();
      _viewModel = new FormViewModel();
      _viewModel.CurrentObject = new TestObject();
      textBox1.DataBindings.Add("Text", _viewModel, "CurrentObject.TestPropertyString");
    }
