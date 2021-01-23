    public List<Fellow> fellowList { get; set; }
    // Constructor
    public MainPage()
    {
        InitializeComponent();
        fellowList = new List<Fellow>();
        for (int i = 0; i < 2; i++)
        {
            Fellow fellow = new Fellow();
            fellow.Name = "Danish " + i;
            fellow.Email = "Email " + i;
            fellowList.Add(fellow);
        }
        this.DataContext = this;
        //lbFellows.ItemsSource = null;
        lbFellows.ItemsSource = fellowList;
    }
    public class Fellow
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
