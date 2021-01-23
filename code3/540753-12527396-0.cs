    public class MyAwesomeProgram: ICertificatePolicy
    {
    	public MyAwesomeProgram() {}
    	
    	public bool CheckValidationResult (ServicePoint sp, 
    		X509Certificate certificate, WebRequest request, int error)
    	{
    		//This is where you should validate the remote certificate
    		return true;
    	}
     
    	public void FetchAwesomeStuff (string url) 
    	{
    		ServicePointManager.CertificatePolicy = this;
    		var wr = WebRequest.Create (url);
    		var stream = wr.GetResponse().GetResponseStream ();
    		Console.WriteLine (new StreamReader (stream).ReadToEnd ());
    	}
    }
