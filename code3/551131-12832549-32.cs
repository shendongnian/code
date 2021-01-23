    public class VoltageModel : INotifyPropertyChanged
    {
        public string ChannelName { get; set; }
        private string m_voltageText;
        public string VoltageText
        {
            get { return m_voltageText; }
            set 
            { 
                m_voltageText = value;
                OnPropertyChanged("VoltageText");
            }
        }
        public ICommand VoltageCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
