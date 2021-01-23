    public ProductCollection GuaranteedProductCollections
          {
            get
              {
                if (_guaranteedProductCollection.Count > 0)
                  {
                     return _guaranteedProductCollection;
                  }
                else
                  {
                    _guaranteedProductCollection = MWProductGuaranteedHelper.CheckGuaranteedProductsFromList(ProdCollection);  // the problem appears to be here... 
                    return _guaranteedProductCollection;
                  }
               }
          }
