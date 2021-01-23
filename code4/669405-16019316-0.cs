    public void InvokePropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
           handler(this, e);
           Refresh();
        }
        if (e.PropertyName.Equals("PostedDateTime"))
        lblDateTimeDt.Text = PostedDateTime == DateTime.MinValue ? "" : PostedDateTime.ToString();
}
