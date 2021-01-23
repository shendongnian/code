        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName == "SelectedYear")
            {
                // populate subj collection which will update the combobox
            }
        }
