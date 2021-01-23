    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GlyphItems = new List<object>();
            var font = @"C:\WINDOWS\Fonts\TIMES.TTF";
            for (int i = 0; i < new GlyphTypeface(new Uri(font)).GlyphCount; i++)
            {
                GlyphItems.Add(new { FontUri = font, Indices = i.ToString() });
            }
            DataContext = this;
        }
        public List<object> GlyphItems { get; set; }
    }
