     string data;
            var request = HttpWebRequest.Create("http://yourserver") as HttpWebRequest;
            request.Accept = "text/xml";
            request.Headers.Add("Accept-Charset", "utf-8");
            try
            {
                var response = await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
               
                // do something with your data, e.g. read it, deserialize it
                using (var responseStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        data = reader.ReadToEnd();
                    }
                    // ....
                }
                var somethingInteresting = response as HttpWebResponse;
                Debug.WriteLine("Status is {0}", somethingInteresting.StatusCode);
            }
            catch (WebException ex)
            {
                var errorResponse = ex.Response as HttpWebResponse;
                var errorHttpStatusCode = errorResponse.StatusCode;
                Debug.WriteLine("Here's your error Http status: {0}", ex.Status);
            }
