                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(new Uri(url, UriKind.Absolute), StoredCookieCollection._CookieCollection);
                request.BeginGetResponse(new AsyncCallback(GetSomething), request);
    
               private void GetSomething(IAsyncResult asynchronousResult)
               {
                  // do something
               }
               // where in url a jsession value is added to the request as &jsessionid=value
