    public IEnumerable<string> GetSomeEnumerable()
    {
    	using (Disposable.Empty)
    	{
    		yield return DoSomeWork();
    	}
    }
