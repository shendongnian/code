    public void OnAddingNewItem(object sender, AddingNewItemEventArgs e)
            {
                ChildClass item = new ChildClass();
                var queryable = SelectedBaseObject.SCollection.OfType<ChildClass>().ToList();
    
                queryable.Add(item);
    
                SelectedBaseObject.SCollection = new QueryableCollectionView(new ObservableCollection<ChildClass>(queryable));
    
                
                ((RadDataForm) sender).BeginEdit();
                e.Cancel = true;
            }
 
     
  
