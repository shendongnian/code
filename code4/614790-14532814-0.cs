    public static void UpdateMyServiceAddress(WebServiceMyProxies.MyServiceClient client)
            {
                client.Endpoint.Address = UpdateServiceAddress(client.Endpoint.Address.Uri.ToString());
            }
    private static System.ServiceModel.EndpointAddress UpdateServiceAddress(string originalAddress)
            {
                int svcIndex = originalAddress.IndexOf(".svc");
                int serviceNameIndex = originalAddress.LastIndexOf('/', svcIndex);
                string serviceName = originalAddress.Substring(serviceNameIndex + 1);
    
                string baseAddress = Application.Current.Host.Source.ToString();
                baseAddress = baseAddress.Substring(0, baseAddress.LastIndexOf('/')); // removing /App.xap
                baseAddress = baseAddress.Substring(0, baseAddress.LastIndexOf('/')); // removing /ClientBin
    
                return new System.ServiceModel.EndpointAddress(String.Format("{0}/{1}/{2}", baseAddress,"Services", serviceName));
            }
