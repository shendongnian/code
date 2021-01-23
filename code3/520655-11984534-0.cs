    public ProductCollection GuaranteedProductCollections
    {
        get
        {
            if (_guaranteedProductCollection == null)
            {
                _guaranteedProductCollection = _WProductGuaranteedHelper.CheckGuaranteedProductsFromList(ProdCollection);
            }
            return _guaranteedProductCollection;
        }
    }
