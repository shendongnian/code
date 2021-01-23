    public class ViewModel : INotifyPropertyChanged
    {
      ViewModel()
      {
        Products = new ObservableCollection<Product>();
        Products.CollectionChanged += OnProductsChanged;
      }
      public ObservableCollection<Product> Products { get; private set; }// the children
      public decimal TotalAmount { get { return Products.Select(p => p.Amount).Sum(); } }
      private void OnProductChanged(object sender, PropertyChangedEventArgs eventArgs)
      {
         if("Amount" != eventArgs.PropertyName)
               return;
         NotifyChanged("TotalAmount");
      }
      private void OnProductsChanged(object sender, NotifyCollectionChangeEventArgs eventArgs)
      {
         // This ignores a collection Reset...
         // Process old items first, for move cases...
         if (eventArgs.OldItems != null)
           foreach(Product item in eventArgs.OldItems)
             item.PropertyChanged -= OnProductChanged;
         if (eventArgs.NewItems != null)
           foreach(Product item in eventArgs.NewItems)
            item.PropertyChanged += OnProductChanged;
         
         
         NotifyChanged("TotalAmount");
      }
    }
