        private string _selectedItem;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (value != WhatIWant)
                {
                    return;
                }
                _selectedItem = value; 
            }
        }
