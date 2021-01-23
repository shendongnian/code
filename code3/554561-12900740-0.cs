    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += OnLoad;
        }
        private const string AccessToken = "xxxxxxxxxxxxxx";
        private const string imgType = "image/jpeg";
        private const string fPath = "c:\bob.jpg";
        private const string userMsg = "My Message";
        private async void OnLoad(object sender, EventArgs e)
        {
            await DoSomething();
        }
        private async Task DoSomething()
        { 
            var fb = new FacebookClient(AccessToken);
            using (var file = new FacebookMediaStream
            {
                ContentType = imgType,
                FileName = Path.GetFileName(fPath)
            }.SetValue(File.OpenRead(fPath)))
            {
                dynamic result = await fb.PostTaskAsync("me/photos",
                    new { message = userMsg, file });
            }
        }
    }
