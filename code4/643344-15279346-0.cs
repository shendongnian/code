        private string _CommandString;
        public string CommandString
        {
             set { _CommandString = GetCommandString(commandtype); }
             get { return _CommandString; }
        }
