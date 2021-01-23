    var categoryModel = ds.Tables[1].Rows.Cast<DataRow>()
                          .Select(x => x["Category"].ToString())
                          .Distinct()
                          .Select(y => new LanguageCategory(OnChecked) { CategoryName = y, IsChecked = true });
   
    public void OnChecked()
    {
       //reload list or whatever
    }
    public class LanguageCategory : INotifyPropertyChanged
    {
        private string _categoryName;
        private bool   _isChecked;
        private Action _checkedCallback;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public LanguageCategory(Action checkedCallback)
        {
           _checkedCallback = checkedCallback;
        }
        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                _categoryName = value;
                NotifyPropertyChanged("CategoryName");
            }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                NotifyPropertyChanged("IsChecked");
                _checkedCallback();
            }
        }
        //snip rest of code
    }
