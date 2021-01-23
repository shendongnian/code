        /// <summary>
        /// The <see cref="SelectedPriority" /> property's name.
        /// </summary>
        public const string SelectedPriorityPropertyName = "SelectedPriority";
        private string _selectedPriority = "normalny";
        /// <summary>
        /// Sets and gets the SelectedPriority property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SelectedPriority
        {
            get
            {
                return _selectedPriority;
            }
            set
            {
                if (_selectedPriority == value)
                {
                    return;
                }
                RaisePropertyChanging(SelectedPriorityPropertyName);
                _selectedPriority = value;
                RaisePropertyChanged(SelectedPriorityPropertyName);
            }
        }
