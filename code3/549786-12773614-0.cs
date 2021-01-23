        private DateTime _LastCheck = DateTime.MinValue;
        private private void bgWSniffer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (_LastCheck.AddSeconds(2) <= DateTime.Now)
            {
                _LastCheck = DateTime.Now;
                // do the UI update.
            }
        }
