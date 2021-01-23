    namespace BackupCiscoConfigs
    {
        class DeviceInterface : INotifyPropertyChanged
        {
            private string tftpIP;
            private string tftpDIR;
            private string command;
            private string dirDate;
            private ObservableCollection<Task> _results;
            public event PropertyChangedEventHandler PropertyChanged;
            // This method is called by the Set accessor of each property. 
            // The CallerMemberName attribute that is applied to the optional propertyName 
            // parameter causes the property name of the caller to be substituted as an argument. 
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public ObservableCollection<Task> results 
            { 
                get
                {
                    return _results;
                }
                set
                {
                    _results = value;
                    NotifyPropertyChanged();
                }
            }
            
            public DeviceInterface(string tftpIP, string tftpDIR, string cmd)
            {
                this.tftpIP = tftpIP;
                this.tftpDIR = tftpDIR;
                this.command = cmd;
                dirDate = DateTimeOffset.Now.ToString("MM.dd.yyyy.HH.mm.ss");
                Directory.CreateDirectory(tftpDIR + dirDate);
            }
    
            public void RunCommands(List<Device> devices)
            {
                results = new ObservableCollection<Task>();
                foreach (Device d in devices)
                {
                    Device d1 = d;
                    d1.command = command + " tftp://" + tftpIP + "/" + dirDate + "/" + d1.ip + ".cfg";
                    results.Add(Task<string>.Factory.StartNew(() => d1.BackupDevice()));
                }
                string res = "";
                foreach (Task<string> t in results)
                {
                    string message = t.Result + "\n";
                    res += message;
                }
                MessageBoxResult msg = MessageBox.Show(res);
            }
        }
    }
