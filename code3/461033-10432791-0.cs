    public class UserInfo
    {
        public string single_token { get; set; }
        public string username { get; set; }
        public string version { get; set; }
    }
    public partial class Downloader : Form
    {
        public Downloader(string url, bool showTags = false)
        {
            InitializeComponent();
            WebClient client = new WebClient();
            string jsonURL = "http://localhost/jev";
            source = client.DownloadString(jsonURL);
            richTextBox1.Text = source;
            JavaScriptSerializer parser = new JavaScriptSerializer();
            var info = parser.Deserialize<UserInfo>(source);
            // use deserialized info object
        }
    }
