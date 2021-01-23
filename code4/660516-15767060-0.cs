    public partial class MainWindow : Window
    {
       private string[] FilePaths {get;set;}
       int imageNum = 0;
       public MainWindow()
       {
        InitializeComponent();
       }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
        openFileDialog1.Filter = "Images (.jpg)|*.jpg";
        openFileDialog1.FilterIndex = 1;
        openFileDialog1.Multiselect = true;
        bool? userClickedOK = openFileDialog1.ShowDialog();
        if (userClickedOK == true)
        {
            FilePaths = openFileDialog1.FileNames;
            
            lblFilePath.Content = filePaths[imageNum];
        }
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        imageNum++;
         if(imageNum<FilePaths.Length)
             lblFilePath.Content = FilePaths[imageNum];
    }
   }
