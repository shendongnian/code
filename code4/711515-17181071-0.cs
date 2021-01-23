    class Storage : ViewModelBase
    {
         ObservableCollection<Shelf> Shelves { get; private set; }
         ...........
    }
    class Shelf : ViewModelBase
    {
         ObservableCollection<Product> Products { get; private set; }
         ..........
    }
