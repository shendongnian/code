    public class ViewModel : INotifyPropertyChanged
    {
        private string _text;
        private string _candidateValue;
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
                if (null != PropertyChanged)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }
        public string CandidateValue
        {
            get
            {
                return this._candidateValue;
            }
            set
            {
                this._candidateValue = value;
                if (null != PropertyChanged)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
