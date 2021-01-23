    public partial class ThePage : Page
    {
      public ThePage()
      {
         InitializeComponent();
         ContentRendered+= new RoutedEventHandler(Page_Load);
      }
      protected void Page_Load(object sender, EventArgs e)
      {
         MessageBox.Show("hey");
      }
    }
