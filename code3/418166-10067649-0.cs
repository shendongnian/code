            string url = "https://auth.api.rackspacecloud.com/v1.0";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Auth-User:" + userName);
            request.Headers.Add("X-Auth-Key:" + apiKey);
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                string[] keys = response.Headers.AllKeys;
                foreach (var k in keys)
                    Console.WriteLine(response.Headers[k]);
            }
