    public List<Intuit.Ipp.Data.Qbo.Invoice> GetQboUnpaidInvoices(DataServices dataServices, int startPage, int resultsPerPage,  IdType CustomerId)
    {
        StringBuilder requestXML = new StringBuilder();
        StringBuilder responseXML = new StringBuilder();
                
        var requestBody = String.Format("PageNum={0}&ResultsPerPage={1}&Filter=OpenBalance :GreaterThan: 0.00 :AND: CustomerId :EQUALS: {2}", startPage, resultsPerPage, CustomerId.Value);
    
        HttpWebRequest httpWebRequest = WebRequest.Create(dataServices.ServiceContext.BaseUrl + "invoices/v2/" + dataServices.ServiceContext.RealmId) as HttpWebRequest;
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        httpWebRequest.Headers.Add("Authorization", GetDevDefinedOAuthHeader(httpWebRequest, requestBody));
        requestXML.Append(requestBody);
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] content = encoding.GetBytes(requestXML.ToString());
        using (var stream = httpWebRequest.GetRequestStream())
        {
            stream.Write(content, 0, content.Length);
        }
        HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
        using (Stream data = httpWebResponse.GetResponseStream())
        {
            Intuit.Ipp.Data.Qbo.SearchResults searchResults = (Intuit.Ipp.Data.Qbo.SearchResults)dataServices.ServiceContext.Serializer.Deserialize<Intuit.Ipp.Data.Qbo.SearchResults>(new StreamReader(data).ReadToEnd());
            return ((Intuit.Ipp.Data.Qbo.Invoices)searchResults.CdmCollections).Invoice.ToList();
        }
    
    }
    
    protected string GetDevDefinedOAuthHeader(HttpWebRequest webRequest, string requestBody)
    {
    
        OAuthConsumerContext consumerContext = new OAuthConsumerContext
        {
            ConsumerKey = consumerKey,
            ConsumerSecret = consumerSecret,
            SignatureMethod = SignatureMethod.HmacSha1,
            UseHeaderForOAuthParameters = true
    
        };
    
        consumerContext.UseHeaderForOAuthParameters = true;
    
        //URIs not used - we already have Oauth tokens
        OAuthSession oSession = new OAuthSession(consumerContext, "https://www.example.com",
                                "https://www.example.com",
                                "https://www.example.com");
    
    
        oSession.AccessToken = new TokenBase
        {
            Token = accessToken,
            ConsumerKey = consumerKey,
            TokenSecret = accessTokenSecret
        };
    
        IConsumerRequest consumerRequest = oSession.Request();
        consumerRequest = ConsumerRequestExtensions.ForMethod(consumerRequest, webRequest.Method);
        consumerRequest = ConsumerRequestExtensions.ForUri(consumerRequest, webRequest.RequestUri);
        if (webRequest.Headers.Count > 0)
        {
            ConsumerRequestExtensions.AlterContext(consumerRequest, context => context.Headers = webRequest.Headers);
            if (webRequest.Headers[HttpRequestHeader.ContentType] == "application/x-www-form-urlencoded")
            {
                Dictionary<string, string> formParameters = new Dictionary<string, string>();
                foreach (string formParameter in requestBody.Split('&'))
                {
                    formParameters.Add(formParameter.Split('=')[0], formParameter.Split('=')[1]);
                }
                consumerRequest = consumerRequest.WithFormParameters(formParameters);
            }
        }
    
        consumerRequest = consumerRequest.SignWithToken();
        return consumerRequest.Context.GenerateOAuthParametersForHeader();
    }
