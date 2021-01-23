    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowModel(
                new MainWindowTreeViewModel(
                    new MainWindowTreeViewNodeModel(
                        "1",
                        new MainWindowTreeViewNodeModel("A"),
                        new MainWindowTreeViewNodeModel("B"),
                        new MainWindowTreeViewNodeModel("C")),
                    new MainWindowTreeViewNodeModel(
                        "2",
                        new MainWindowTreeViewNodeModel("A"),
                        new MainWindowTreeViewNodeModel("B"),
                        new MainWindowTreeViewNodeModel("C")),
                    new MainWindowTreeViewNodeModel(
                        "3",
                        new MainWindowTreeViewNodeModel("A"),
                        new MainWindowTreeViewNodeModel("B"),
                        new MainWindowTreeViewNodeModel("C"))));
        }
    }
