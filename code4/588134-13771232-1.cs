    /// <summary>
            /// Post this message.
            /// </summary>
            /// <param name="url">URL of the document.</param>
            /// <param name="bytes">The bytes.</param>
            public T Post<T>(string url, byte[] bytes)
        {
            T item;
            var request = WritePost(url, bytes);
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                item = DeserializeResponse<T>(response);
                response.Close();
            }
            return item;
        }
        /// <summary>
        /// Writes the post.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        private static HttpWebRequest WritePost(string url, byte[] bytes)
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            Stream stream = null;
            try
            {
                request.Headers.Clear();
                request.PreAuthenticate = true;
                request.Connection = null;
                request.Expect = null;
                request.KeepAlive = false;
                request.ContentLength = bytes.Length;
                request.Timeout = -1;
                request.Method = "POST";
                stream = request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {
                GetErrorResponse(url, e);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Flush();
                    stream.Close();
                }
            }
            return request;
        }
