    public partial class MainWindow : Window
    {
        List<Familiy> familiys = new List<Familiy>();
        public MainWindow()
        {
            InitializeComponent();
           
            familiys.Add( new Familiy("FirstName1", "LastName1"));
            familiys.Add(new Familiy("FirstName2", "LastName2"));
            familiys.Add(new Familiy("FirstName3", "LastName3"));
            familiys.Add(new Familiy("FirstName4", "LastName4"));
            listView1.ItemsSource = familiys;
            
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            familiys.Remove(familiys.Find(delegate(Familiy f) { return f.FirstName == firstnametxt.Text; }));
            listView1.ItemsSource = "";
            listView1.ItemsSource = familiys;
        }
    }
