    public partial class MainWindow : Window
    {
        private ObservableCollection<Info> _source;
        public MainWindow()
        {
            this.MySource = new ObservableCollection<Info>();
            InitializeComponent();
            this.DataContext = this;
            this.MySource.Add(new Info(){Foreground = Brushes.Red});
        }
        public ObservableCollection<Info> MySource
        {
            get { return _source; }
            set { _source = value; }
        }
    }
    public class Info : DependencyObject
    {
        public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(Info));
        public Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }
        
    }
