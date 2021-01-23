    public class Attachment : INotifyPropertyChanged
    {
    
        private string dwgNo;
        public string DwgNo{
            get { return dwgNo; }
            set
            {
                dwgNo=value;
                // Call NotifyPropertyChanged when the property is updated
                NotifyPropertyChanged("DwgNo");
            }
        }
      // Declare the PropertyChanged event
      public event PropertyChangedEventHandler PropertyChanged;
      // NotifyPropertyChanged will raise the PropertyChanged event passing the
      // source property that is being updated.
      public void NotifyPropertyChanged(string propertyName)
      {
         if (PropertyChanged != null)
         {
             PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }
      }  
    }
