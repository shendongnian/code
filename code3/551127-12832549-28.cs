    public class ChannelListViewModel
    {
        private ICommand m_voltageCommand;
        public ChannelListViewModel()
        {
            m_voltageCommand = new DelegateCommand(x => SetCommandExecute(x));
        }
        public void Initialize()
        {
            VoltageCollection = new ObservableCollection<VoltageModel> { new VoltageModel() { ChannelName = "VDD__Main", VoltageText = String.Empty, VoltageCommand = m_voltageCommand },
                                                                         new VoltageModel() { ChannelName = "VDD__IO__AUD", VoltageText = String.Empty, VoltageCommand = m_voltageCommand },
                                                                         new VoltageModel() { ChannelName = "VDD__CODEC__AUD", VoltageText = String.Empty, VoltageCommand = m_voltageCommand }};
        }
        public ObservableCollection<VoltageModel> VoltageCollection { get; set; }
        public void SetCommandExecute(object voltageText)
        {
            Debug.WriteLine(voltageText);
        }
    }
