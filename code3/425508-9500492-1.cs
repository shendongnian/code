    internal static class SystemContext
    {
        private static ObservableCollection<Person> _people = null;
        public static ObservableCollection<Person> People
        {
            get
            {
                if( _people == null )
                {
                    _people = new ObservableCollection<Person>();
                    // load the list here from a service or something
                }
     
                return _people;
            }
        }
    }
