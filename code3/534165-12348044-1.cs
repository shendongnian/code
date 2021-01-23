    WebRequest myRequest = WebRequest.Create("http://www.example.com");
    using (WebResponse myResponse = myRequest.GetResponse())
    {
        myResponse.SaveAs(...)
    }
...
    public static class WebResponseExtensions
    {
    	public static void SaveAs(this WebResponse response, string filePath)
    	{
    		using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    		{
    			File.AppendAllText(filePath, myResponse.Headers.ToString());
    			File.AppendAllText(filePath, reader.ReadToEnd());
    		}
    	}
    }
