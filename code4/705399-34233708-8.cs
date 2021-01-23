      public partial class MainWindow
      {
       internal static MainWindow Main; //(1) Declare object as static
       public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           Main =this; //(2) Defined Main (IMP)
          var AnyClassORWindow=new Class1(); //Initialize another Class
          AnyClassORWindow.ShowValue();
        }
      }
