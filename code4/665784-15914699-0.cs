    public class ViewModelProperties : INotifyPropertyChanged {
    public event ProeprtyChangedEventHandler PropertyChanged;
    
    private ObservableCollection<ServerProperties> properties = new ObservableCollection<ServerProperties>();
    
    public ObservableCollection<ServerProperties> Properties {
        get { return properties;}
        set {
            properties = value;
            this.RaisePropertyChangedEvent("Properties");
        }
    }
    
    private void RaisePropertyChanged(string propertyName) {
        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    }
