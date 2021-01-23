    public class ColorSettingsSequencesSequence : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _startTemp;
        public string StartTemp { get { return _startTemp; } set { _startTemp = value; OnPropertyChanged("StartTemp");}}
        private string _endTemp;
        public string EndTemp { get { return _endTemp; } set { _endTemp = value; OnPropertyChanged("EndTemp"); } }
    }
