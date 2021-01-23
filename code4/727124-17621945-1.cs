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
    class ParentViewModel
    {
        IList<PersonViewModel> _people;
    
        public ParentViewModel(IList<PersonViewModel> people)
        {
             _people = people;
             foreach (var person in people)
             {
                 person.PropertyChanged += PropertyChanged;
             }
        }
    
        void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //Recreate checked people list
        }
    }
