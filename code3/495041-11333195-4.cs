        private ObservableCollection<Person> _thePeople;
        public ObservableCollection<Person> ThePeople
        {
            get
            {
                if (_thePeople == null)
                {
                    List<Person> list = new List<Person>()
                    {
                        new Person() { name = "Bob" , address = "101 Main St." , age = 1000 },
                        new Person() { name = "Jim" , address = "101 Main St." , age = 1000 },
                        new Person() { name = "Mip" , address = "101 Main St." , age = 1000 },
                    };
                    _thePeople = new ObservableCollection<Person>(list);
                }
                return _thePeople;
            }
        }
