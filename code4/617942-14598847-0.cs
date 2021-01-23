    public partial class MainPage : UserControl
{
    public MainPage()
    {
        InitializeComponent();
        this.Loaded += MainPage_Loaded;
    }
    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        System.Windows.Browser.HtmlPage.Plugin.Focus();
        txtBox.UpdateLayout();
        txtBox.Focus();
    }
