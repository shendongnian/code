    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    
    public class MyAwesomeProgram
    {
    	public MyAwesomeProgram() 
    	{
    		ServicePointManager.ServerCertificateValidationCallback =
                    ValidateServerCertficate;
    	}
    	
    	private static bool ValidateServerCertficate(object sender, X509Certificate certificate,
    		X509Chain chain, SslPolicyErrors sslpolicyerrors)
    	{
    		//This is where you should validate the remote certificate
    		return true;
    	}
     
    	public void FetchAwesomeStuff (string url) 
    	{
    		var wr = WebRequest.Create (url);
    		var stream = wr.GetResponse().GetResponseStream ();
    		Console.WriteLine (new StreamReader (stream).ReadToEnd ());
    	}
    }
