    async public Task<List<XDocument>> GetAzureServices()
        {
            String uri = String.Format("https://management.core.windows.net /{0}/services/hostedservices ", _subscriptionid);
            List<XDocument> services = new List<XDocument>();
            HttpClient http = GetHttpClient();
            Stream responseStream = await http.GetStreamAsync(uri);
            if (responseStream != null)
            {
                XDocument xml = XDocument.Load(responseStream);
                var svcs = xml.Root.Descendants(ns + "HostedService");
                foreach (XElement r in svcs)
                {
                    XDocument vm = new XDocument(r);
                    services.Add(vm);
                }
           }
            return services;
        }
    public HttpClient GetHttpClient()
        {
            WebRequestHandler handler = new WebRequestHandler();
            string CertThumbprint = _certthumbprint;
            X509Certificate2 managementCert = FindX509Certificate(CertThumbprint);
            if (managementCert != null)
            {
                handler.ClientCertificates.Add(managementCert);
                HttpClient httpClient = new HttpClient(handler);
                httpClient.DefaultRequestHeaders.Add("x-ms-version", "2012-03-01");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                return httpClient;
            }
            return null;
        }
    private static X509Certificate2 FindX509Certificate(string thumbprint)
        {
            X509Store certificateStore = null;
            X509Certificate2 certificate = null;
            try
            {
                certificateStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                certificateStore.Open(OpenFlags.ReadOnly);
                var certificates = certificateStore.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);
                if (certificates.Count > 0)
                {
                    certificate = certificates[0];
                }
            }
            finally
            {
                if (certificateStore != null) certificateStore.Close();
            }
            return certificate;
        }
