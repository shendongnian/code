    private ReadOnlyObservableCollection<Advert> _readonlyAds;
    public ReadOnlyObservableCollection<Advert> SquareAdsVertical 
    { 
        get 
        { 
            if (AdsManager.VerticalAds == null) 
            { 
                return null; 
            } 
            else if (_readonlyAds == null)
            {
                // Only one instance of the readonly collection is created
                _readonlyAds = new ReadOnlyObservableCollection<Advert>(AdsManager.VerticalAds);
            }
           
            // Return the read only collection that wraps the underlying ObservableCollection
            return  _readonlyAds;
        } 
    } 
