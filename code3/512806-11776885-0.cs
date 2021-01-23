	public IStorageProvider GetProvider(string typeName, ref IStorageProvider provider)
	{
	    if (provider == null)
		{
			lock (_lock)
			{
				if (provider == null)
				{
					var storageProviderType = Type.GetType(BLL.Providers.ConfigurationProvider.Instance.M4MStorageProviderTypeName);
					provider = (IStorageProvider)Activator.CreateInstance(storageProviderType);
				}
			}
		}
	}
