       CollectionViewSource logViewSource;
       IEnumerable<object> Query;
       IEnumerable<string> objects= new List<string> { "a", "b" };
       Query = objects;
       logViewSource=(CollectionViewSource)(FindResource("logEntriesViewSource"));
       logViewSource.Source = Query;
