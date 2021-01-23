     public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            var student = new Student { StudentFirstName = "John", StudentLastName = "Doe" };
            viewModel.StudentViewModels.Add(new StudentViewModel(student));
            DataContext = viewModel;
            MouseLeftButtonDown += new MouseButtonEventHandler((object sender, MouseButtonEventArgs e) =>
            {
                viewModel.StudentViewModels[0].ChangeStudent();
            });
        }
