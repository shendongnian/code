            private List<SomeType> _list;
        
            public void AddToList(SomeType item)
        {
            _list.Add(item);
            SomeOtherMethod();
        }
        
          public ReadOnlyCollection<SomeType> MyList
        {
           get { return _list.AsReadOnly(); }
    }
