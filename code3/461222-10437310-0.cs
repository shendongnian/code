    //WARNING: typed in SO window
    public class ViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title) 
                {
                    _title = value;
                    this.OnPropertyChanged("Title");
                    this.BeginSaveToServer();
                }
            }
        }
        public void UpdateTitleFromServer(string newTitle)
        {
            _title = newTitle;
            this.OnPropertyChanged("Title"); //alert the view of the change
        }
    }
