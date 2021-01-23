     // Retrieve an IQueryable for the colleciton with your specified conditions
     var query = from c in collection
                 orderby c.IsChecked descending, c.Tag.Equals("cherry") descending, c.obsTag
                 select c;
     // Clear the collection
     collection = new ObservableCollection<myCollectionObject>();
     // Replace the collection with your IQueryable results
     foreach(myCollectionObject obj in query) {
          collection.Add(obj);
     }
