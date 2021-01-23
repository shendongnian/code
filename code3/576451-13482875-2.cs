    protected override IDisposable Run(
        IObserver<TResult> observer, 
        IDisposable cancel, 
        Action<IDisposable> setSink)
    {
    	if (this._timeSelectorA != null)
    	{
    		Generate<TState, TResult>.α α = 
                    new Generate<TState, TResult>.α(
                         (Generate<TState, TResult>) this, 
                         observer, 
                         cancel);
    		setSink(α);
    		return α.Run();
    	}
    	if (this._timeSelectorR != null)
    	{
    		Generate<TState, TResult>.δ δ = 
                   new Generate<TState, TResult>.δ(
                       (Generate<TState, TResult>) this, 
                       observer, 
                       cancel);
    		setSink(δ);
    		return δ.Run();
    	}
    	Generate<TState, TResult>._ _ = 
                 new Generate<TState, TResult>._(
                      (Generate<TState, TResult>) this, 
                      observer, 
                      cancel);
    	setSink(_);
    	return _.Run();
    }
