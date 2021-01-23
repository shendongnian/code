        private string _txtResults = string.Empty;
        public string TxtResults
        {
            get { return this._txtResults; }
           set
           {
                this._txtResults= value;
                 this.RaisePropertyChangedEvent("TxtResults");
            }
        }
