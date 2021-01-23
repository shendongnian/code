    public static T FromTempResource<T, TDisp>(Func<TDisp> dispFunc, Func<TDisp, T> createFunc) where TDisp : IDisposable
    {
    	using(TDisp d = dispFunc())
    	{
    		return createFunc(d);
    	}
    }
