            private bool _isValid;
        public bool IsValid
        {
            get
            {
                string.IsNullOrWhiteSpace(GetValidationError())
                return _isValid;
            }
            set
            {
                _isValid = value;
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
            IsValid=string.IsNullOrWhiteSpace(error);
            return error;
        }
