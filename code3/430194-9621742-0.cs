    public ICollectionView Teachers
    {
       get
       {
          // Persons is your ObservableCollection<Person>.
          var teachers = CollectionViewSource.GetDefaultView(Persons);
          source.Filter = p => (p as Person).Type == "Teacher";
          return source;
       }
    }
