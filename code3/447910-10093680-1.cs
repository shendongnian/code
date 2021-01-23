    MyCollectionViewSource = new CollectionViewSource();
    Binding binding = new Binding();
    binding.Source = MyCollection;
    BindingOperations.SetBinding( MyCollectionViewSource , 
                                  CollectionViewSource.SourceProperty, 
                                  binding );
