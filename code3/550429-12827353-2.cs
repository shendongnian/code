    public class ProductViewModel
    {
        public int Temperature { get; set; }
        private product _currentProduct;
        public Product CurrentProduct 
        { 
            get { return _currentProduct; }
            set
            {
                if (value != _currentProduct)
                {
                    if (_currentProduct != null)
                        _currentProduct.RemoveValidationDelegate(ValidateProduct);
                    _currentProduct = value;
                    if (_currentProduct != null)
                        _currentProduct.AddValidationDelegate(ValidateProduct);
                    RaisePropertyChanged("CurrentProduct");
                }
            }
        }
    
        // Product Validation Delegate to verify temperature
        private string ValidateProduct(object sender, string propertyName)
        {
            if (propertyName == "Rating")
            {
                if (CurrentProduct.Rating > Temperature)
                    return "Rating is too high for current temperature";
            }
            return null;
        }
    }
