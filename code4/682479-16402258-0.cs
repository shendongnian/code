    public IObservable<double> GetData()
    {
		Action<object, double> dataHandler = (s, e) => { i.OnNext(e); };
        return Observable.Create<double>(i => 
        {   
            _externalPriceService.OnDataChanged += dataHandler;
            return Disposable.Create(() => 
            {
                _externalPriceService.OnDataChanged -= dataHandler;
            });
        });
    }    
