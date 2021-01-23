    using System;
    using System.IO;
    using System.Net;
    					
    public class Program
    {
    	public static void Main()
    	{
    		try {
       			// Create a web request for an invalid site. Substitute the "invalid site" strong in the Create call with a invalid name.
    			HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("invalid URL");
    
    			// Get the associated response for the above request.
    			HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();
    			myHttpWebResponse.Close();
    		}
    		catch(WebException e) {
    			Console.WriteLine("This program is expected to throw WebException on successful run."+
    							  "\n\nException Message :" + e.Message);
    			if(e.Status == WebExceptionStatus.ProtocolError) {
    				Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
    				Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
    				using (StreamReader r = new StreamReader(((HttpWebResponse)e.Response).GetResponseStream()))
    				{
    					Console.WriteLine("Content: {0}", r.ReadToEnd());
    				}
    			}
    		}
    		catch(Exception e) {
    			Console.WriteLine(e.Message);
    		}
    	}
    }
