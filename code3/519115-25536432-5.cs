    public MyView()
    {
        var viewModel = new StudyDataStructureViewModel(studyId);
        this.DataContext = viewModel;
        
        //InitializeComponent(); ...
        
        viewModel.ClosingRequest += (sender, e) => this.Close();
    }
