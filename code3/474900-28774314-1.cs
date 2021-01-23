	public static int GetObjectAppDomain(object proxy)
	{
		RealProxy rp = RemotingServices.GetRealProxy(proxy);
		int id = (int)rp.GetType().GetField("_domainID", BindingFlags.Instance|BindingFlags.NonPublic).GetValue(rp);
		return id;
	}
