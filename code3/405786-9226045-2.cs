      public partial class MainPage : UserControl
      {
         public MainPage()
         {
            InitializeComponent();
            customerListBoxMain.ItemsSource = PersonDataProvider.GetData();
         }
       }
