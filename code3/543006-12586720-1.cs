    public void Test(object searchCriteria)
		{
			YourClient proxy = new YourClient();
			proxy.GetObject(searchCriteria);
			proxy.SafeClose();
		}
