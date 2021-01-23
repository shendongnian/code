    public class ViewModel : INotifyPropertyChanged
    {
        public PersonViewModel Person1
        {
            get { return _person1; }
            set
            {
                _person1 = value;
                RaisePropertyChangedEvent("Person1"); 
                //So, whenever a property within my Person1 changes, raise event for that property.
            }
        }
        public PersonViewModel Person2
        {
            get { return _person2; }
            set
            {
                _person2 = value;
                RaisePropertyChangedEvent("Person2");
            }
        }
    }
