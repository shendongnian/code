    public class DataObject : INotifyPropertyChanged
    {
        private string header;
        private string content;
        public string Header {
            get { return header; }
            set { header = value; RaisePropertyChanged("Header"); }
        }
        public string Content {
            get { return content; }
            set { content= value; RaisePropertyChanged("Content"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName) {
            var handler = PropertyChanged;
            if (handler != null) { 
                handler(this, new PropertyChangedEventArgs(propertyName)); 
            }
        }
    }
