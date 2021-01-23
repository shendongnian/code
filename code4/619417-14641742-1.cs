    namespace DataGridWithMultipleTypesPerColumn
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new ViewModel();
            }
        }
        public class ViewModel
        {
            public ObservableCollection<string> ControlTypes
            {
                get;
                private set;
            }
            public ViewModel()
            {
                ControlTypes = new ObservableCollection<string>() { "Button", "TextBox", "CheckBox" };
            }
        }
    }
