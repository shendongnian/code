    public ObservableCollection<int> ValidBaudRateCollection;
    public SerialComm()
    {
        this.ValidBaudRateCollection = new ObservableCollection<int>(this.ValidBaudRate);
        _serialPort = new SerialPort();
    }
