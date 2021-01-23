            private bool _isValid;
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = string.IsNullOrWhiteSpace(GetValidationError());
                NotifyPropertyChanged("IsValid");
            }
        }
        public string GetValidationError()
        {
            string error = null;
            if (ValidatedProperties != null)
            {
                foreach (string s in ValidatedProperties)
                {
                    error = GetValidationError(s);
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        break;
                    }
                }
            }
            return error;
        }
