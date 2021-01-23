    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            IList<string> names = new List<string>();
            names.Add("Alexander");
            names.Add("Bobby");
            names.Add("Chris");
            names.Add("Dean");
            ListBox.ItemsSource = names;
            foreach (var name in names.Where(x => x != "Bobby"))
            {
                ListBox.SelectedItems.Add(name);
            }
        }
    }
