    private ObservableCollection<MyTabContent> _contents = new  ObservableCollection<MyTabContent>();
    public ObservableCollection<MyTabContent> Contents { get { return _contents; } }
-
    public class MyTabContent : INotifyPropertyChanged
    {
        private int _id;
        int ID {
            get{ return _id; }
            set{ _id = value; OnPropertyChanged(); }
        }
    
        private string _subText;
        public string Subtext {
            get{ return _subText; }
            set{ _subText= value; OnPropertyChanged(); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        { 
            if (PropertyChanged!= null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
