        public Boolean IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                    // handle selection here...
                }
            }
        }
        private Boolean isSelected;
