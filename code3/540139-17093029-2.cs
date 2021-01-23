    class Foo
    {
        private DateTime _modificationDate;
        public DateTime ModificationDate
        {
            get { return _modificationDate; }
            set { _modificationDate = DateTime.SpecifyKind(value, DateTimeKind.Utc); }
        }
        //Ifs optional? since it's always going to be a UTC date, and any DB call will return unspecified anyways
    }
