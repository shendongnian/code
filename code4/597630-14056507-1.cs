     PropertyInfo[] inf = WebOperationContext.Current.IncomingRequest.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
                    HttpRequestMessageProperty val = (HttpRequestMessageProperty)inf[0].GetValue(WebOperationContext.Current.IncomingRequest, null);
                    string paramString = HttpUtility.UrlDecode(val.QueryString, Encoding.GetEncoding(1251));
                    Uri address = new Uri("http://server.ru/services/service.svc/reg?" + paramString);
                    p1 = HttpUtility.ParseQueryString(address.Query).Get("p1");
                    p2 = HttpUtility.ParseQueryString(address.Query).Get("p2");
                    p3 = HttpUtility.ParseQueryString(address.Query).Get("p3");
                    ...
