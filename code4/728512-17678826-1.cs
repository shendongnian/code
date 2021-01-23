    public string ProductName
    {
      get { return currentProduct.ProductName; }
      set 
      {
        if (currentProduct.ProductName != value)
        {
          currentProduct.ProductName = value;
          base.OnPropertyChanged("ProductName");
        }
      }  
    }
