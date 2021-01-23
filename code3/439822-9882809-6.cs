    public class OrderViewModel
    {
            private List<ProductViewModel> _products;
            public int OrderNumber { set; get; }
            public List<ProductViewModel> Products
            {
                get
                {
                    if (_products == null)
                    {
                        _products = new List<ProductViewModel>();
                        _products.Add(new ProductViewModel { ID = 1, Name = "Ketchup" });
                        _products.Add(new ProductViewModel { ID = 1, Name = "Mustard" });
                        _products.Add(new ProductViewModel { ID = 1, Name = "Relish" });
                        _products.Add(new ProductViewModel { ID = 1, Name = "Mayo" });
                    }
                    return _products;
                }
            }
           public int SelectedProductId { set;get;}
    }
