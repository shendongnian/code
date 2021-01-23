    public class YourClass: INotifyPropertyChanged
      {
          private string description;
          public event PropertyChangedEventHandler PropertyChanged;
    
          public string Description
          {
              get { return description; }
              set
              {
                  description= value;
                  OnPropertyChanged("Description");
              }
          }
    
          // Create the OnPropertyChanged method to raise the event 
          protected void OnPropertyChanged(string name)
          {
              PropertyChangedEventHandler handler = PropertyChanged;
              if (handler != null)
              {
                  handler(this, new PropertyChangedEventArgs(name));
              }
          }
      }
