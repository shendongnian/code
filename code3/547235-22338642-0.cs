    void Main()
    {
        var ms = new MemoryStream();
        var ser = new DataContractJsonSerializer(typeof(Job));
        ser.WriteObject(ms, new Job { Comments = "Test", Title = "TestTitle", Id = 1 });
	
        var uri = new Uri("http://SomeRestService/Job");
        var servicePoint = ServicePointManager.FindServicePoint(uri);
        servicePoint.Expect100Continue = false;
	
        var webClient = new WebClient();
        webClient.Headers["Content-type"] = "application/json";
	
        IWebProxy defaultProxy = WebRequest.DefaultWebProxy;
        if (defaultProxy != null){
            defaultProxy.Credentials = CredentialCache.DefaultCredentials;
    	    webClient.Proxy = defaultProxy;
        }
	
        try {
            var result = webClient.UploadData(uri, "POST", ms.ToArray());
        } catch (WebException we) {
            var response = (HttpWebResponse)we.Response;
        }
    }
    [DataContract]
    public class Job
    {
        [DataMember (Name="comments", EmitDefaultValue=false)]
        public string Comments { get; set; }
        [DataMember (Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }
        [DataMember (Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }
    }
