    public class Client : INotifyPropertyChanged
    {
       //other fields/properies
       private string firstName;
       private string lastName;
    
       public string FirstName
       {
          get { return this.firstName; }
          set 
          {
             this.firstName = value;
             this.FirePropertyChanged("FirstName");
             this.FirePropertyChanged("DisplayName");
          }
       }
    
       public string LastName
       {
          get { return this.firstName; }
          set 
          {
             this.lastName = value;
             this.FirePropertyChanged("LastName");
             this.FirePropertyChanged("DisplayName");
          }
       }
    
       public string DisplayName
       {
          get 
          {
              return string.Format("{0} {1}", this.firstName, this.lastName);
          }
       }
     
       protected void FirePropertyChanged(string propertyName)
       {
          if (this.PropertyChanged != null)
             this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
       }
    }
