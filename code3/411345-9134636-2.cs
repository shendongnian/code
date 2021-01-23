        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {    
            
            // Making sure we have a HttpRequestMessageProperty
            HttpRequestMessageProperty httpRequestMessageProperty;
            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {     
                httpRequestMessageProperty = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                if (httpRequestMessageProperty == null)
                {      
                    httpRequestMessageProperty = new HttpRequestMessageProperty();
                    request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessageProperty);
                } 
            }
            else
            {     
                httpRequestMessageProperty = new HttpRequestMessageProperty();
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessageProperty);
            } 
            // Add the authorization header to the WCF request    
            httpRequestMessageProperty.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(Service.Proxy.ClientCredentials.UserName.UserName + ":" + Service.Proxy.ClientCredentials.UserName.Password)));
            return null;
        }    
