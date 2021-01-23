    public partial class DataGridCustomCells : Window
        {
            public ICommand CellButtonCommand { get; set; }
    
            public DataGridCustomCells()
            {
                CellButtonCommand = new Command<object>(OnCellCommandExecuted){IsEnabled = true};
    
                InitializeComponent();
    
                DataContext = new List<DataGridSampleData>
                    {
                        new DataGridSampleData() {LastName = "Simpson", FirstName = "Homer", ShowButtonOnFirstName = true},
                        new DataGridSampleData() {LastName = "Szyslak", FirstName = "Moe", ShowButtonOnLastName = true},
                        new DataGridSampleData() {LastName = "Gumble", FirstName = "Barney", ShowButtonOnFirstName = true},
                        new DataGridSampleData() {LastName = "Burns", FirstName = "Montgomery", ShowButtonOnLastName = true},
                    };
            }
    
            private void OnCellCommandExecuted(object parameter)
            {
                MessageBox.Show("Command Executed: " + parameter);
            }
        }
