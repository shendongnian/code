    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new List<TabItemModel>
            {
                new TabItemModel
                {
                    Header = "First"
                },
                new TabItemModel
                {
                    Header = "Second"
                },
            };
        }
    }
    public class TabItemModel
    {
        public string Header
        {
            get;
            set;
        }
    }
