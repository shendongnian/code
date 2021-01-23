    private void DataModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged -= DataModel_PropertyChanged;
        PropertyInfo toPropertyInfo = this.GetType().GetProperty(e.PropertyName);
        PropertyInfo fromPropertyInfo = DataModel.GetType().GetProperty(e.PropertyName);
    
        if (toPropertyInfo != null && fromPropertyInfo != null)
        {
            if (toPropertyInfo.CanWrite && fromPropertyInfo.CanRead)
            {
                toPropertyInfo.SetValue(this, fromPropertyInfo.GetValue(DataModel, null), null);
            }
        }
        OnPropertyChanged += DataModel_PropertyChanged;
    }
