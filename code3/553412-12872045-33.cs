    public class MyViewModel
    {
        public ICollectionView Customers { get; set; }
        public void MoveSelectionLeft()
        {
            Customers.MoveCurrentToPrevious();
        }
        public void MoveSelectionRight()
        {
            Customers.MoveCurrentToNext();
        }
        public MyViewModel()
        {
            Customers = new CollectionViewSource
                {
                    Source = new[]
                        {
                            new Customer {Name = "John", Age = 25},
                            new Customer {Name = "Jane", Age = 27},
                            new Customer {Name = "Dawn", Age = 31}
                        }
                }.View;
        }
    }
