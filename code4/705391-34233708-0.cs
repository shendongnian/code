      public partial class MainWindow
      {
       internal static MainWindow Main; //declare object as static
       public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           Main = (MainWindow)Application.Current.MainWindow; //defined Main
          var AnyClassORWindow=new Class1(); //Initialize another Class
          AnyClassORWindow.ShowValue();
        }
      }
