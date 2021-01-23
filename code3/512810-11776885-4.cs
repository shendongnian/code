	public void GetProvider(string typeName, ref IStorageProvider provider)
	{
	    if (provider == null)
		{
			lock (_lock)
			{
				if (provider == null)
				{
					var storageProviderType = Type.GetType(typeName);
					provider = (IStorageProvider)Activator.CreateInstance(storageProviderType);
				}
			}
		}
	}
