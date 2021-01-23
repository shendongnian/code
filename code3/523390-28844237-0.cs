	private void ConfigureTransactionTimeout(TimeSpan value)
	{
		//initializing internal stuff
		// ReSharper disable once NotAccessedVariable
		var timespan = TransactionManager.MaximumTimeout;
		//initializing it again to be sure
		// ReSharper disable once RedundantAssignment
		timespan = TransactionManager.MaximumTimeout;
		SetTransactionManagerField("_cachedMaxTimeout", true);
		SetTransactionManagerField("_maximumTimeout", value);
		Condition.Ensures(TransactionManager.MaximumTimeout, "TransactionManager.MaximumTimeout").IsEqualTo(value);
	}
	private void SetTransactionManagerField(string fieldName, object value)
	{
		var cacheField = typeof (TransactionManager).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static);
		Condition.Ensures(cacheField, "cacheField").IsNotNull();
		cacheField.SetValue(null, value);
	}
