    public int CPUUsage
            {
                get { return _cpuUsage; }
                set
                {
                    _cpuUsage = value;
                    NotifyPropertyChanged("CPUUsage"); // Notify CPUUsage not _cpuUsage
                }
            }
