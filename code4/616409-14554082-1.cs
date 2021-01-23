    public partial class MainWindow : Window
    {
        private ObservableCollection<Link> _links = new ObservableCollection<Link>();
        public MainWindow()
        {
            InitializeComponent();
            Links.Add(new Link { Name = "StackOverflow", Site = new Uri("http://stackoverflow.com/") });
            Links.Add(new Link { Name = "Google", Site = new Uri("http://www.google.com/") });
        }
        public ObservableCollection<Link> Links
        {
            get { return _links; }
            set { _links = value; }
        }
    }
    // ListBox item
    public class Link
    {
        public string Name { get; set; }
        public Uri Site { get; set; }
    }
    // helper calss to create AttachedProperty
    public static class WebBrowserHelper
    {
        public static readonly DependencyProperty LinkSourceProperty =
            DependencyProperty.RegisterAttached("LinkSource", typeof(string), typeof(WebBrowserHelper), new UIPropertyMetadata(null, LinkSourcePropertyChanged));
        public static string GetLinkSource(DependencyObject obj)
        {
            return (string)obj.GetValue(LinkSourceProperty);
        }
        public static void SetLinkSource(DependencyObject obj, string value)
        {
            obj.SetValue(LinkSourceProperty, value);
        }
        // When link changed navigate to site.
        public static void LinkSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var browser = o as WebBrowser;
            if (browser != null)
            {
                string uri = e.NewValue as string;
                browser.Source = uri != null ? new Uri(uri) : null;
            }
        }
    }
