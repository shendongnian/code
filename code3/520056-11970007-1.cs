    public partial class YourDialog  : Window
    {
         public MainWindow.MenuClickedDelegate MenuClickCallback;
         public YourDialog()
         {
             InitializeComponent();
         }
    
         private void Edit_Click6S(object sender, RoutedEventArgs e)
         {
             this.close();
             MenuClickCallback;
         }
    }
