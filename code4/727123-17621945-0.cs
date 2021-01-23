    class Person //Model
    {
        public string Name {get;set;}
        public string ImgPath {get;set;}
    }
    
    class PersonViewModel : INotifyPropertyChanged
    {
        readonly Person _person;
    
        public string Name {get {return _person.Name;}}
        public string ImgPath {get {return _person.ImgPath; }}
    
        public bool IsChecked {get;set;} //implement INPC here
    
        public PersonViewModel(Person person)
        {
            _person = person;
        }
    }
