      public partial class MainWindow
      {
       internal static MainWindow Main; //(1) Declare object as static
       public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           Main = (MainWindow)Application.Current.MainWindow; //(2) Defined Main
          var AnyClassORWindow=new Class1(); //Initialize another Class
          AnyClassORWindow.ShowValue();
        }
      }
