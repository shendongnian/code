    public string ComboBoxSelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                if (int.parse(value) < 3)
                {
                    _selectedIndex = value;
                }
                OnPropertyChanged("ComboBoxSelectedIndex");
                Trace.WriteLine(ComboBoxSelectedIndex);
            }
        }
