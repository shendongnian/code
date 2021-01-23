    public class VoltageModel
    {
        public string ChannelName { get; set; }
        string voltageText = string.Empty;
        public string VoltageText
        {
            get
            {
                return voltageText;
            }
            set
            {
                voltageText = value;
            }
        }
        public ICommand VoltageCommand { get; set; }
    }
