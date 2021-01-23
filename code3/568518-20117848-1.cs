	public bool DeleteTableEntity(string partitionKey, string rowKey)
	{
		try
		{
			_table.Execute(TableOperation.Delete(new TableEntity(partitionKey, rowKey) { ETag = "*" }));
			return true;
		}
		catch (StorageException e)
		{
			if (e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.NotFound)
				return false;
			throw;
		}
	}
