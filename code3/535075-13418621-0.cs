                    public static void Main()
            {
                string baseAddress = "https://" + Environment.MachineName + ":8000";
                ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
                BasicHttpBinding basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
                host.AddServiceEndpoint(typeof(ITest), basicHttpBinding, "basic");
                WebHttpBinding webHttpBinding = new WebHttpBinding(WebHttpSecurityMode.Transport);
                HttpTransportSecurity httpTransportSecurity = webHttpBinding.Security.Transport;
                httpTransportSecurity.ClientCredentialType = HttpClientCredentialType.None;
                httpTransportSecurity.ProxyCredentialType = HttpProxyCredentialType.None;
                WebHttpBehavior webHttpBehavior = new WebHttpBehavior();
                
                host.AddServiceEndpoint(typeof(IPolicyRetriever), webHttpBinding, "").Behaviors.Add(webHttpBehavior);
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpsGetEnabled = true;
                host.Description.Behaviors.Add(smb);
                host.Open();
                Console.WriteLine("Host opened");
            }
