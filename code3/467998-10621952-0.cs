    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResourceDictionary dic = App.Current.Resources;
            dic[typeof (TextBlock)] = null;
        }
    }
