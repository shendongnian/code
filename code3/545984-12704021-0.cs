     public static void method()
            {
             //   NetworkCredential myCredentials = new NetworkCredential("username", "password", "aaa.onmicrosoft.com");
                WebClient w = new WebClient();
                var ua = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
                w.Headers["Accept"] = "/";
                w.Headers.Add(HttpRequestHeader.UserAgent, ua);
                w.Credentials = myCredentials;
              //I changed this for my own application, your code was fine :)
