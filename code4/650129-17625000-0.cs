    public partial class MyPage : PhoneApplicationPage
    {
        public MyPage()
        {
            InitializeComponent();
            BuildApplicationBar();
        }
        private void BuildApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.    
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.IsVisible = true;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsMenuEnabled = true;
            // Create new buttons
            ApplicationBarIconButton AppBarAddButton = new ApplicationBarIconButton(new Uri("/Assets/check.png", UriKind.Relative));
            AppBarAddButton.Text = "Add";
            AppBarAddButton.Click += new EventHandler(AppBarAddButton_Click);
            ApplicationBar.Buttons.Add(AppBarAddButton);
            ApplicationBarIconButton AppBarNewButton = new ApplicationBarIconButton(new Uri("/Assets/add.png", UriKind.Relative));
            AppBarNewButton.Text = "New";
            AppBarNewButton.Click += new EventHandler(AppBarNewButton_Click);
            ApplicationBar.Buttons.Add(AppBarNewButton);
        }
        private async void AppBarAddButton_Click(object sender, EventArgs e)
        {
            //TODO: Do something for the add click action
        }
        private async void AppBarNewButton_Click(object sender, EventArgs e)
        {
            //TODO: Do something for the new click action
        }
    }
