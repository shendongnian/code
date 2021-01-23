    public ProductCollection GuaranteedProductCollections
    {
        get
        {
            if (_guaranteedProductCollection == null)
            {
                _guaranteedProductCollection = WProductGuaranteedHelper.CheckGuaranteedProductsFromList(ProdCollection);
            }
            return _guaranteedProductCollection;
        }
    }
