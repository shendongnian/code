       private ObservableCollection<ProductDTO> _lstProduct;
       public ObservableCollection<ProductDTO> LstProduct
            {
                get { return _lstProduct; }
                set
                {
                    _lstProduct = value;
                    RaisePropertyChanged("LstProduct");
                }
            }
    
       /// <summary>
        /// Get all Commonly Used Products
        /// </summary>
        /// <returns>returns list of all Commonly Used  products present in database</returns>
    private void FillCommonProducts()
    {
        LstProduct = new ObservableCollection<ProductDTO>(from item in ServiceFactory.ServiceClient.GetCommonProduct() 
                                   select item);
    }
