    public class MyDocumentViewModel: INotifyPropertyChanged //Or whatever viewmodel base class
    {
        private string _header;
        public string Header 
        {
            get { return _header; }
            set
            {
                _header = value;
                NotifyPropertyChange(() => Header);
             }
         }
         //Whatever other data you need
    }
