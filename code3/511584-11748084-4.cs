    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            WebClient client = new WebClient();
            client.OpenReadCompleted += (s, e) =>
                {
                    using (Stream stream = e.Result)
                    {
                        BitmapImage img = new BitmapImage();
                        img.SetSource(stream);
                        // Update MyImage.Source. Use the Dispatcher to ensure this happens on the UI Thread
                        Dispatcher.BeginInvoke(() =>
                            {
                                MyImage.Source = img;
                            });
                        
                    }
                };
            client.OpenReadAsync(new Uri(String.Format(BaseURL + "MyHandler.ashx")));
        }
    }
