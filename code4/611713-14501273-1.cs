    public class RecordTemp : INotifyPropertyChanged
    {
        List<PartsList> _value = new List<PartsList>();
       public RecordTemp()
        {
            _value.Add(new PartsList() { ArticleID = "1", ArticleName = "one - 1", ArticleQuantity = 20 });
            _value.Add(new PartsList() { ArticleID = "2", ArticleName = "Two - 2", ArticleQuantity = 10 });
        }
        public List<PartsList> GetPersonList()
        {
            return _value;
        }
        private PartsList _SelectedPart;
        
        public PartsList SelectedPart
        {
            get { return _SelectedPart; }
            set
            {
                _SelectedPart = value;
                 OnPropertyChanged("SelectedPart");
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null  )
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }     
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        
        #endregion
    }
     public class PartsList
	{
	    public string ArticleID { get; set; }
	    public double ArticleQuantity { get; set; }
	    public string ArticleName { get; set; }
        }
