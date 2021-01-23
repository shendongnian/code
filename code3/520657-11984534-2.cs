    public ProductCollection GuaranteedProductCollections
    {
        get
        {
            return _guaranteedProductCollection
                ?? _guaranteedProductCollection = WProductGuaranteedHelper.CheckGuaranteedProductsFromList(ProdCollection);
        }
    }
