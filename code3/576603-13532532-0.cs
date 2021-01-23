     HttpClient client = new HttpClient();
                    /*Set Credentials to authenticate proxy*/
                    client.TransportSettings.Proxy = new WebProxy(proxyAddress);
                    client.TransportSettings.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    client.TransportSettings.Credentials = CredentialCache.DefaultCredentials;
    
                    client.BaseAddress = new Uri(this.baseUrl);
                    var response = client.Get(fullUrl);
    
                    var jsonResponce = response.Content.ReadAsJsonDataContract<mYResponseoBJECT>();
    
    
     public static T ReadAsJsonDataContract<T>(this  HttpContent content)
            {
                return (T)content.ReadAsJsonDataContract<T>(new DataContractJsonSerializer(typeof(T)));
            }
