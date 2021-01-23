        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged("Name"); }
        }
        public string this[string columnName]
        {
            get
            {
                if (CanValidate)
                {
                    if (columnName == "Name")
                    {
                        if (!ValidateName())
                        {
                            return "Error";
                        }
                    }
                }
                return "";
            }
        }
        private bool canValidate;
        public bool CanValidate
        {
            get { return canValidate; }
            set { canValidate = value; RaisePropertyChanged("CanValidate"); RaisePropertyChanged("Name");}
        }
        private bool ValidateName()
        {
            if (String.IsNullOrEmpty(Name))
            {
                return false;
            }
            return true;
        }
