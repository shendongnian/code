        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (_refreshing) return "Refreshing";
                return ValidationEngine.For(this.GetType()).GetError(this, columnName);
            }
        }
        
        bool _refreshing = false;
        public void RefreshValidation()
        {
            _refreshing = true;
            this.NotifyOfPropertyChange(string.Empty);
            _refreshing = false;
            this.NotifyOfPropertyChange(string.Empty);
        }
