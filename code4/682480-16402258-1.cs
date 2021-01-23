    public IObservable<double> GetData()
    {
		Action<object, double> dataHandler = null;
        return Observable.Create<double>(i => 
        {   
			dataHandler = (s, e) => { i.OnNext(e); };;
            _externalDataService.OnDataChanged += dataHandler;
            return Disposable.Create(() => 
            {
                _externalDataService.OnDataChanged -= dataHandler;
            });
        });
    }    
