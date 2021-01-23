public partial class MainWindow : Window 
{
    public ObservableCollection<string> ListBoxInput
    {
            get; private set;
    }
    public MainWindow()
    {
       InitializeComponent();
       this.ListBoxInput = new ObservableCollection<string>();
       this.DataContext = this;
    }
    private void AddListBoxEntry_Click(object sender, RoutedEventArgs e)
    {
       this.ListBoxInput.Add("Hello " + DateTime.Now.ToString());
    }
}
