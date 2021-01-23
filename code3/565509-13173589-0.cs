        public async void PerformHttpGet(string url,out string responseText)
        {
            int respCode = 0;
            try
            {
                // used to build entire input
                StringBuilder sb = new StringBuilder();
                // used on each read operation
                byte[] buf = new byte[8192];
                // prepare the web page we will be asking for
                HttpClient searchClient;
                searchClient = new HttpClient();
                searchClient.MaxResponseContentBufferSize = 256000;
                HttpResponseMessage response = await searchClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseText = await response.Content.ReadAsStringAsync();
            }
            catch (WebException e)
            {
                string text = string.Empty;
                string outRespType = string.Empty;
                if (e.Response != null)
                {
                    using (WebResponse response = e.Response)
                    {
                        outRespType = response.ContentType;
                        HttpWebResponse exceptionResponse = (HttpWebResponse)response;
                        respCode = (int)exceptionResponse.StatusCode;
                        using (System.IO.Stream data = response.GetResponseStream())
                        {
                            text = new System.IO.StreamReader(data).ReadToEnd();
                        };
                    };
                }
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
