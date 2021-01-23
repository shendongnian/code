    public class MySession
    {
    	public UploadResults UploadFile()
    	{
    		try
    		{
    			//try upload
    			
    			return UploadResults.Succeeded();
    		}
    		catch (Exception ex)
    		{
    			return UploadResults.Failed(ex);
    		}
    	}
    }
    
    public class UploadResults
    {
    	public bool Success { get; private set; }
    	public Exception FailureReason { get; private set; }
    	
    	
    	private UploadResults(bool success, Exception failureReason)
    	{
    		this.Success = success;
    		this.FailureReason = failureReason;
    	}
    	
    	internal static UploadResults Succeeded()
    	{
    		return new UploadResults(true, null);
    	}
    	
    	internal static UploadResults Failed(Exception failureReason)
    	{
    		return new UploadResults(false, failureReason);
    	}
    }
