    public class DemoValidationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private ColorSettingsSequencesSequence _currentSequence;
        public ColorSettingsSequencesSequence CurrentSequence
        {
            get { return this._currentSequence; }
            set
            {
                this._currentSequence = value;
                OnPropertyChanged("CurrentSequence");
            }
        }
        public List<ColorSettingsSequencesSequence> ColorSettingsSequences { get; private set; }
        public DemoValidationViewModel()
        {
            // dummy data
            this.ColorSettingsSequences = new List<ColorSettingsSequencesSequence>()
            {
                new ColorSettingsSequencesSequence() { StartTemp = "10", EndTemp = "20" },
                new ColorSettingsSequencesSequence() { StartTemp = "20", EndTemp = "30" },
                new ColorSettingsSequencesSequence() { StartTemp = "30", EndTemp = "40" }
            };
        }
    }
