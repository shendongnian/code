    public class VMPerson : INotifyPropertyChange
    {
       public Person PersonItem {get; set;}
    
       public VMPerson()
       {
          PersonItem = new Person();
       }
    }
