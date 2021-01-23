    namespace Testing_learning
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        public class NameList : ObservableCollection<Shortcuts>
        {
            ...
        }
    
        public class Shortcuts
        {
            ...
        }
    }
