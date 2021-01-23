    public class MotionTitleItem 
    {
    string _name = string.Empty;
    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
        OnPropertyChanged("Name");
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string propertyName)
    {
      try
      {
        PropertyChangedEventHandler eventHandler = this.PropertyChanged;
        if (null == eventHandler)
          return;
        else
        {
          var e = new PropertyChangedEventArgs(propertyName);
          eventHandler(this, e);
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
