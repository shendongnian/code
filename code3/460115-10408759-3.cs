     private ObservableCollection<ModelProductInformation> productInfoCollection;
     //ctor, just once in the constructor
     this.productInfoCollection =  new ObservableCollection<ModelProductInformation>();
     this.ProductInfoView = CollectionViewSource.GetDefaultView(productInfoCollection);
     new ProductInfoSearch(ProductInfoView, this.TestTextBox);
    private void RibbonSetupProduct_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        this.hidePanels();
        new Task(() =>
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                var yourData = from ProductInfo in new GTS_ERPEntities().ProductInformations select new ModelProductInformation { ProductID = ProductInfo.ProductID,  ProductName = ProductInfo.ProductName , Remark=ProductInfo.Remark};
                //if you wanna change the collection, simple clear and add(or create AddRange extension)
               this.productInfoCollection.Clear();
               foreach(var data in yourData)
               { this.productInfoCollection.Add(data);}
            }
                ), DispatcherPriority.DataBind);
        }
        ).Start(); 
        this.PanelProducts.Visibility = Visibility.Visible;
    }
     
