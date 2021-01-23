    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        this.DataContext = new MSGviewModel();
        InitializeComponent();
      }
    }
