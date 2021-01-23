    public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    
        public class MainViewModel : NotificationObject
        {
            public MainViewModel()
            {
                SearchPerson = new DelegateCommand(this.OnSearchPerson);        
    
                // test data
                _myDataSource.Add(new Person { Name = "John", Surname = "Blob" });
                _myDataSource.Add(new Person { Name = "Jack", Surname = "Smith" });
                _myDataSource.Add(new Person { Name = "Adam", Surname = "Jackson" });
            }
    
            private List<Person> _myDataSource = new List<Person>();
    
            private string _searchString;
            public string SearchString
            {
                get { return _searchString; }
                set { _searchString = value; RaisePropertyChanged(() => SearchPerson); }
            }
    
            private ICollectionView _people;
            public ICollectionView People
            {
                get { return CollectionViewSource.GetDefaultView(_myDataSource); }           
            }
    
            public ICommand SearchPerson { get; private set; }
            private void OnSearchPerson()
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    People.Filter = (item) => { return (item as Person).Name.StartsWith(SearchString) || (item as Person).Surname.StartsWith(SearchString) ? true : false; };
                }
                else
                    People.Filter = null;
            }
        }
