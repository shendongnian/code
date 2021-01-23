        protected IEnumerable<Invoice> GetInvoicesWithOpenBalance(DataServices dataServices, int startPage, int resultsPerPage)
        {
            try
            {
                Intuit.Ipp.Security.OAuthRequestValidator oAuthRequestValidator = ((Intuit.Ipp.Security.OAuthRequestValidator)dataServices.ServiceContext.RequestValidator);
                OAuthConsumerContext consumerContext = new OAuthConsumerContext
                {
                    ConsumerKey = oAuthRequestValidator.ConsumerKey,
                    SignatureMethod = SignatureMethod.HmacSha1,
                    ConsumerSecret = oAuthRequestValidator.ConsumerSecret
                };
                OAuthSession oSession = new OAuthSession(consumerContext, "https://www.example.com",
                                        "https://www.example.com",
                                        "https://www.example.com");
                oSession.AccessToken = new TokenBase
                {
                    Token = oAuthRequestValidator.AccessToken,
                    ConsumerKey = oAuthRequestValidator.ConsumerKey,
                    TokenSecret = oAuthRequestValidator.AccessTokenSecret
                };
                var body = "PageNum={0}&ResultsPerPage={1}&Filter=OpenBalance :GreaterThan: 0.01";
                body = String.Format(body, startPage, resultsPerPage);
                IConsumerRequest conReq = oSession.Request();
                conReq = conReq.Post().WithRawContentType("application/x-www-form-urlencoded").WithRawContent(System.Text.Encoding.ASCII.GetBytes(body)); ;
                conReq = conReq.ForUrl(dataServices.ServiceContext.BaseUrl + "invoices/v2/" + dataServices.ServiceContext.RealmId);
                conReq = conReq.SignWithToken();
                Intuit.Ipp.Data.Qbo.SearchResults searchResults = (Intuit.Ipp.Data.Qbo.SearchResults)dataServices.ServiceContext.Serializer.Deserialize<Intuit.Ipp.Data.Qbo.SearchResults>(conReq.ReadBody());
                return ((Intuit.Ipp.Data.Qbo.Invoices)searchResults.CdmCollections).Invoice;
            }
            catch (Exception)
            {
                return null;
            }
        }
