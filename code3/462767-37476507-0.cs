        public bool IsChecked 
        {
            get { return isChecked; }
            set 
            {
                isChecked = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }
