    public partial class MainWindow : Window
    {
        private NameList _nameList;
    
        public NameList NameList
        {
            get { return _nameList; }
            set
            {
                if (_nameList != value)
                {
                    _nameList = value;
                }
             }
        }
    
        public MainWindow ()
        {
            InitializeComponent(); 
            
            NameList = new NameList();
        }
    }
