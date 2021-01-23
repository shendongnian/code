    using System;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
     
    public class Program : ICertificatePolicy {
     
    	public bool CheckValidationResult (ServicePoint sp, 
    		X509Certificate certificate, WebRequest request, int error)
    	{
    		return true;
    	}
     
    	public static void Main (string[] args) 
    	{
    		ServicePointManager.CertificatePolicy = new Program ();
    		WebRequest wr = WebRequest.Create (args [0]);
    		Stream stream = wr.GetResponse ().GetResponseStream ();
    		Console.WriteLine (new StreamReader (stream).ReadToEnd ());
    	}
    }
