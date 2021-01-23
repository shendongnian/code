    public TResult InvokeService<TServiceContract, TResult>(Func<TServiceContract, TResult> invokeHandler) where TServiceContract : class
		{
			ICommunicationObject communicationObject;
			var arg = CreateCommunicationObject<TServiceContract>(out communicationObject);
			var result = default(TResult);
			try
			{
				result = invokeHandler(arg);
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
				throw;
			}
			finally
			{
				try
				{
					if (communicationObject.State != CommunicationState.Faulted)
						communicationObject.Close();
				}
				catch
				{
					communicationObject.Abort();
				}
			}
			return result;
		}
    private TServiceContract CreateCommunicationObject<TServiceContract>(out ICommunicationObject communicationObject)
			where TServiceContract : class
		{
			//Create the Channel
            // ICommunicationObject is an out parameter for disposing purposes 
			return channel;
		}
