        set
        {
            if (value != _isSelected)
            {
                _isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
            else if(_isSelected)
            {
                IsSelected = false;
            }
        }
