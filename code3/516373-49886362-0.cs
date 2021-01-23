    private string _baseUrl = "https://xxxxxx.atlassian.net";
    private string _username = "YourLogin";
    
    void Main()
    {
    	RunQuery(JiraResource.project).JsonToXml().Dump();
    }
    
    public enum JiraResource { project }
    
    private const string restApiVersion = "/rest/api/2/";
    
    protected string RunQuery(	JiraResource resource,	string argument = null,	string data = null,	string method = "GET")
    {
    	string url = $"{_baseUrl}{restApiVersion}{resource}";
    
    	if (argument != null) url = $"{url}{argument}/";
    
    	var request = WebRequest.Create(url) as HttpWebRequest;
    	request.ContentType = "application/json";
    	request.Method = method;
    
    	if (data != null)
    	{
    		using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
    		{
    			writer.Write(data);
    		}
    	}
    	string base64Credentials = GetEncodedCredentials();
    	request.Headers.Add("Authorization", "Basic " + base64Credentials);
    
    	var response = request.GetResponse() as HttpWebResponse;
    	string result = string.Empty;
    	using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    	{
    		result = reader.ReadToEnd();
    	}
    	return result;
    }
    
    private string GetEncodedCredentials()
    {
    	var encryptedPassword = Environment.GetEnvironmentVariable("PassEncrypted");
    	var encryptionSalt = Environment.GetEnvironmentVariable("PassSalt");
    	var password = encryptedPassword.Decrypt(encryptionSalt);
    
    	var mergedCredentials = $"{_username}:{password}";
    	var byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
    	return Convert.ToBase64String(byteCredentials);
    }
    
    public static class MyExtensions
    {
    	public static XElement JsonToXml(this string jsonData, bool isAddingHeader = true)
    	{
    		var data = isAddingHeader
    			? "{\"record\":" + jsonData + "}"
    			: jsonData;
    
    		data = data // Complains if xml element name starts numeric
    			.Replace("16x16", "n16x16")
    			.Replace("24x24", "n24x24")
    			.Replace("32x32", "n32x32")
    			.Replace("48x48", "n48x48");
    
    		var result = JsonConvert.DeserializeXmlNode(data, "data");
    		var xmlResult = XElement.Parse(result.OuterXml);
    		return xmlResult;
    	}
    }
    
    
