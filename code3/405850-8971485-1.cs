    public class ClientViewModel: INotifyPropertyChanged
    {
       private string firstName;
       private string lastName;
    
       public string FirstName
       {
          get { return this.firstName; }
          set 
          {
             this.firstName = value; // Dont forget to raise PropertyChanged!
          }
       }
    
       public string LastName
       {
          get { return this.firstName; }
          set 
          {
             this.lastName = value;
          }
       }
    }
