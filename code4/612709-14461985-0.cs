    public class MainWindowViewModel : ViewModelBase
    {
        private RecordModel _recordModel;
    
        public MainWindowViewModel()
        {
            RecordModel = new RecordModel(); // set the property not the field
        }
    
        public RecordModel RecordModel
        {
            get { return _recordModel; }
            set {
                _recordModel = value;
                // populate CategoryList here from value.CategoryList
            }
        }
    
        public UnknownType CategoryList { get; }
    }
