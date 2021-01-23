        private HttpClient PrepareHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));
            return client;
        }
        private string SendGetRequest(string url)
        {
            //Please be patient ...
            this.Cursor = Cursors.WaitCursor;
            var client = PrepareHttpClient();
            txtSent.Text = url;
            var taskReult = client.GetAsync(new Uri(url));
            HttpResponseMessage httpResponse = taskReult.Result;
            Stream st = httpResponse.Content.ReadAsStreamAsync().Result;
            StreamReader reader = new StreamReader(st);
            string content = reader.ReadToEnd();
            //Reset the cursor shape
            this.Cursor = Cursors.Default;
 
            txtReceived.Text = FormatResponse(httpResponse, content);
            //For GET we expect a response of 200 OK
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return content;
            }
 
            throw new ApplicationException(content);
        }
        /// <summary>
        /// Post to the server using JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The server uri</param>
        /// <param name="e">The object to POST</param>
        /// <returns></returns>
        private string SendPostRequest<T>(string url, T e)
        {
            this.Cursor = Cursors.WaitCursor;
            HttpClient client = new HttpClient();
            // Create the JSON formatter.
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            // Use the JSON formatter to create the content of the request body.
            HttpContent content = new ObjectContent<T>(e, jsonFormatter);
            Stream st = content.ReadAsStreamAsync().Result;
            StreamReader reader = new StreamReader(st);
            string s = reader.ReadToEnd();
            // Send the request.
            var taskResult = client.PostAsync(url, content);
            //Note: We could simply perform the following line and save some time
            //but then we will not have access to the post content:
            //var taskResult = client.PostAsJsonAsync<T>(url, e);
           
            HttpResponseMessage httpResponse = taskResult.Result;
            this.Cursor = Cursors.Default;
            txtSent.Text = FormatRequest(httpResponse.RequestMessage, s);
            st = httpResponse.Content.ReadAsStreamAsync().Result;
            reader = new StreamReader(st);
            string responseContent = reader.ReadToEnd();
            txtReceived.Text = FormatResponse(httpResponse, responseContent);
            //For POST we expect a response of 201 Created
            if (httpResponse.StatusCode == HttpStatusCode.Created)
            {
                return responseContent;
            }
            throw new ApplicationException(responseContent);
        }
        /// <summary>
        /// PUT to the server using JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private string SendPutRequest<T>(string url, T e)
        {
            this.Cursor = Cursors.WaitCursor;
            HttpClient client = new HttpClient();
            // Create the JSON formatter.
            MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
            // Use the JSON formatter to create the content of the request body.
            HttpContent content = new ObjectContent<T>(e, jsonFormatter);
            Stream st = content.ReadAsStreamAsync().Result;
            StreamReader reader = new StreamReader(st);
            string s = reader.ReadToEnd();
            // Send the request.
            var taskResult = client.PutAsync(url, content);
            //Note: We could simply perform the following line and save some time
            //but then we will not have access to the post content:
            //var taskResult = client.PutAsJsonAsync<T>(url, e);
            HttpResponseMessage httpResponse = taskResult.Result;
            txtSent.Text = FormatRequest(httpResponse.RequestMessage, s);
            st = httpResponse.Content.ReadAsStreamAsync().Result;
            reader = new StreamReader(st);
            string responseContent = reader.ReadToEnd();
            this.Cursor = Cursors.Default;
            txtReceived.Text = FormatResponse(httpResponse, responseContent);
            //For PUT we expect a response of 200 OK
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return responseContent;
            }
            throw new ApplicationException(responseContent);
        }
        private string FormatRequest(HttpRequestMessage request, string content)
        {
            return
                string.Format("{0} {1} HTTP/{2}\r\n{3}\r\n{4}",
                    request.Method,
                    request.RequestUri,
                    request.Version,
                    request.Headers,
                    content);
        }
        private string FormatResponse(HttpResponseMessage result, string content)
        {
            return
                string.Format("HTTP/{0} {1} {2}\r\n{3}\r\n{4}",
                    result.Version,
                    (int)result.StatusCode,
                    result.ReasonPhrase,
                    result.Headers,
                    content);
        }
