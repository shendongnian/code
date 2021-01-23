    WebException webException = ex as WebException;
	if (webException != null && (webException.Status == WebExceptionStatus.ProtocolError || webException.Status == WebExceptionStatus.ConnectionClosed))
	{
		return true;
	}
	DataServiceRequestException dataServiceException = ex as DataServiceRequestException;
	if (dataServiceException != null && StorageTransientErrorDetectionStrategy.IsErrorStringMatch(StorageTransientErrorDetectionStrategy.GetErrorCode(dataServiceException), new string[]
	{
		"InternalError", 
		"ServerBusy", 
		"OperationTimedOut", 
		"TableServerOutOfMemory"
	}))
	{
		return true;
	}
	StorageServerException serverException = ex as StorageServerException;
	if (serverException != null)
	{
		if (StorageTransientErrorDetectionStrategy.IsErrorCodeMatch(serverException, new StorageErrorCode[]
		{
			1, 
			2
		}))
		{
			return true;
		}
		if (StorageTransientErrorDetectionStrategy.IsErrorStringMatch(serverException, new string[]
		{
			"InternalError", 
			"ServerBusy", 
			"OperationTimedOut"
		}))
		{
			return true;
		}
	}
	StorageClientException storageException = ex as StorageClientException;
	return (storageException != null && StorageTransientErrorDetectionStrategy.IsErrorStringMatch(storageException, new string[]
	{
		"InternalError", 
		"ServerBusy", 
		"TableServerOutOfMemory"
	})) || ex is TimeoutException;
