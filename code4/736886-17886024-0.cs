    public class MedicationList : INotifyPropertyChanged {
      public int MedicationID { get; set; }
      private string m_Description;
      public string Description {
        get { return m_Description; }
        set {
          m_Description = value;
          OnPropertyChanged("Description");
        }
      }
      private void OnPropertyChanged(string propertyName) {
        if (string.IsNullOrEmpty(propertyName))
          throw new ArgumentNullException("propertyName");
        var changed = PropertyChanged;
        if (changed != null) {
          changed(this, new PropertyChangedEventArgs(propertyName));
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
    }
