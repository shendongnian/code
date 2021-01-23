    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        if(propertyName == "ToDoBills")
            UpdateSumValue();
    }
    private void UpdateSumValue()
    {
         Sum = ToDoBills.Sum(i => i.Amount);
    }
