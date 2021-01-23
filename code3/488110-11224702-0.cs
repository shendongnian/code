    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    using System.Net;
    
    private static void CheckSite(string url, string method)
    {
    	X509Certificate2 cert = null;
    	ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
    
    	X509Store store = new X509Store(StoreLocation.LocalMachine);
    	store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
    	X509Certificate2Collection certcollection = (X509Certificate2Collection)store.Certificates;
    	// pick a certificate from the store
    	cert = X509Certificate2UI.SelectFromCollection(certcollection, 
    			"Caption",
    			"Message", X509SelectionFlag.SingleSelection)[0];
    
    	store.Close();
    
    	HttpWebRequest ws = (HttpWebRequest)WebRequest.Create(url);
    	ws.Credentials = CredentialCache.DefaultCredentials;
    	ws.Method = method;
    	if (cert != null)
    		ws.ClientCertificates.Add(cert);
    
    	using (HttpWebResponse webResponse = (HttpWebResponse)ws.GetResponse())
    	{
    		using (Stream responseStream = webResponse.GetResponseStream())
    		{
    			using (StreamReader responseStreamReader = new StreamReader(responseStream, true))
    			{
    				string response = responseStreamReader.ReadToEnd();
    				Console.WriteLine(response);
    				responseStreamReader.Close();
    			}
    
    			responseStream.Close();
    		}
    		webResponse.Close();
    	}
    }
    
    /// <summary>
    /// Certificate validation callback.
    /// </summary>
    private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
    {
    	// If the certificate is a valid, signed certificate, return true.
    	if (error == System.Net.Security.SslPolicyErrors.None)
    	{
    		return true;
    	}
    
    	Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
    		cert.Subject,
    		error.ToString());
    
    	return false;
    }
