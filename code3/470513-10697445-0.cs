    internal class FileParser:ImageFileParser, INotifyPropertyChanged
    {
        private decimal _pct;
        internal decimal PercentComplete { 
            get { return _pct; }
            set {
                _pct = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PercentComplete"));
            }
        }
        PropertyChanged(this, new PropertyChangedEventArgs(info));
        ImageFileParser.GenerateCmds()
        {
            PercentComplete = change;    //0 to 100
            //long time operation
        }
    }
