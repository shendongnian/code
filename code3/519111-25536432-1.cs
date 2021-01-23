    public MyView()
        {
            //InitializeComponent(); ...
            viewModel.ClosingRequest += (sender, e) => this.Close();
        }
