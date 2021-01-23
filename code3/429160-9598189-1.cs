    public class Model: INotifyPropertyChanged
    {
      private string _YourProperty;
      public string YourProperty
      {
        get { return _YourProperty; }
        set
        {
          if (_YourProperty == value) return;
          _YourProperty = value;
          RaisePropertyChanged("YourProperty");
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      private void RaisePropertyChanged(string propertyName)
      {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    
    public class ViewModel: INotifyPropertyChanged
    {
      private Model _Model;
    
      public ViewModel(Model model)
      {
        _Model = model;
        _Model.PropertyChanged += OnModelPropertyChanged;
      }
    
      public string YourProperty
      {
        get { return _Model.YourProperty; }
      }
    
      private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
      {
        if (e.PropertyName == "YourProperty")
          RaisePropertyChanged("YourProperty");
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      private void RaisePropertyChanged(string propertyName)
      {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
