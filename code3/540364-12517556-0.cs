            private string _busyText;
            public string BusyText
            {
                get { return _busyText; }
                set { _busyText = value; RaisePropertyChanged(() => BusyText); }
            }
