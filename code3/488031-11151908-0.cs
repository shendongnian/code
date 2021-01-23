    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
    
    
            public ObservableCollection<GroupBox> BindingTest
            {
                get
                {
                    ObservableCollection<GroupBox> collection = new ObservableCollection<GroupBox>();
                    for (int counter = 0; counter < 5; counter++)
                    {
                        GroupBox groupBox = new GroupBox();
                        groupBox.Header = " ... Header ... ";
                        groupBox.Content = " ... Content ... ";
                        collection.Add(groupBox);
                    }
    
                    return collection;
                }
            }
        }
