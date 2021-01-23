    using System.Windows;
    
    namespace gregory.bmclub
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = new EmployeeListViewModel();
            }
        }
    }
