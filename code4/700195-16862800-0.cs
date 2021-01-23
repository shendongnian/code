    public class PersonViewModel : INotifyPropertyChanged
    {
       private Person _person;
       public PersonViewModel(Person person)
       {
           _person = person;
       }
       public string Name
       {
           get 
           {
               return _person.Name;
           }
           set
           {
              _person.Name = value;
              RaiseNotifyPropertyChanged("Name");
           }
        }
    }
