    public partial class MainPage : PhoneApplicationPage
    {
        private const int NumTabs = 4;
        private int currentIndex;
        private string[] urls = new string[NumTabs];
        private WebBrowser[] browsers = new WebBrowser[NumTabs];
        public MainPage()
        {
            InitializeComponent();
            ShowTab(0);
        }
        private void ShowTab(int index)
        {
            this.currentIndex = index;
            UrlTextBox.Text = this.urls[this.currentIndex] ?? "";
            if (this.browsers[this.currentIndex] == null)
            {
                WebBrowser browser = new WebBrowser();
                this.browsers[this.currentIndex] = browser;
                BrowserHost.Children.Add(browser);
            }
            for (int i = 0; i < NumTabs; i++)
            {
                if (this.browsers[i] != null)
                {
                    this.browsers[i].Visibility = i == this.currentIndex ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }
        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Uri url;
                if (Uri.TryCreate(UrlTextBox.Text, UriKind.Absolute, out url))
                {
                    this.urls[this.currentIndex] = UrlTextBox.Text;
                    this.browsers[this.currentIndex].Navigate(url);
                }
                else
                    MessageBox.Show("Invalid url");
            }
        }
        private void TabMenuItem_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(((ApplicationBarMenuItem)sender).Text) - 1;
            ShowTab(index);
        }
    }
