    public class MyDesignTimeViewModel
    {
        public ObservableCollection<Person> People
        {
            get 
            { 
                return new ObservableCollection<Person> { 
                                                            new Person 
                                                                { 
                                                                    Name = "Simon" 
                                                                },
                                                            new Person 
                                                                { 
                                                                    Name = "Jack" 
                                                                } 
                                                        }; 
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
    }
