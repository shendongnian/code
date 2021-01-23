    public sealed partial class SamplePage : Page
    {
        ObservableCollection<ROWS> r = new ObservableCollection<ROWS>();
        public SamplePage()
        {
            this.InitializeComponent();
            r.Add(new ROWS { Integer = 1, String = "ONE" });
            r.Add(new ROWS { Integer = 2, String = "TWO" });
            r.Add(new ROWS { Integer = 3, String = "THREE" });
            r.Add(new ROWS { Integer = 4, String = "FOUR" });
            r.Add(new ROWS { Integer = 5, String = "FIVE" });
            ListViewDisplay.ItemsSource = r;
        }
    }
    public class ROWS {
        public int Integer { get; set; }
        public string String { get; set; }
    }
