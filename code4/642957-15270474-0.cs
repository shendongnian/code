        private void GetNewsResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ObservableCollection<NewsSerializer>));
            var res = (IList<NewsSerializer>)ser.ReadObject(streamResponse);
            News.Clear();
            foreach(var item in res)
            {
                News.Add(item);
            }
        }
