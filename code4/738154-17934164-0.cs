    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
    public class Datum
    {
        public DateTime Date { get; set; }
        public string Year { get { return Date.ToString("yyy"); } }
        public string Month { get { return Date.ToString("MMMM"); } }
        public string Day { get { return Date.ToString("dd"); } }
        public string Weekday { get { return Date.ToString("dddd"); } }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            // data
            var _Data = Enumerable.Range(1, 20)
                .Select(x => new Datum { Date = DateTime.Now.Add(TimeSpan.FromDays(x * 14)) });
            Data = new ObservableCollection<Datum>(_Data);
        }
        public ObservableCollection<Datum> Data { get; private set; }
    }
