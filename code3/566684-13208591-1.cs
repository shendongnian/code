    public partial class MainWindow : Window,  INotifyPropertyChanged
    {
        private const string cLorem = @"Lorem ipsum dolor sit amet consectetur adipiscing elit Maecenas
                                       et lacinia nisl Aenean nec aliquet risus Phasellus dui purus 
                                       sollicitudin nec cursus vitae cursus id purus Nam quis risus 
                                       velit Sed aliquam tellus in odio pulvinar tincidunt Sed bibendum mi";
    
    
    
        private int Skip { get; set; }
        private ObservableCollection<string> _RegComboList;
        public event PropertyChangedEventHandler PropertyChanged;
    
        public ObservableCollection<string> RegComboList
        {
            get { return _RegComboList; }
            set
            {
                _RegComboList = value;
                OnPropertyChanged();
            }
        }
    
    
        public MainWindow()
        {
            InitializeComponent();
            RegComboList = new ObservableCollection<string>();
            GenerateWords(5);
    
            DataContext = this;
        }
    
        private void GenerateWords(int toTake)
        {
            RegComboList.Clear();
    
            Regex.Split(cLorem, @"\s+").Skip(Skip)
                 .Take(toTake)
                 .ToList()
                 .ForEach(word => RegComboList.Add( word ));
    
            Skip += toTake;
        
        }
    
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = "" )
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GenerateWords(new Random().Next(1, 10));
        } 
    }
