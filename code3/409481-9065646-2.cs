    public class MyHeader : DataGridColumnHeader, INotifyPropertyChanged
    {
        private string _myContent;
        public string MyContent
        {
            get { return _myContent;}
            set { _myContent = value;
                if(PropertyChanged!=null)
                     PropertyChanged(this, new PropertyChangedEventArgs("MyContent"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
