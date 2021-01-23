    public partial class MainWindow : Window
    {
      public MailWindow()
      {
        InitializeComponent();
        this.DataContext = new WindowsViewModel();
      }
    }
