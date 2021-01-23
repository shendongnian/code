    var request = HttpWebRequest.Create("http://www.maplegraphservices.com/tokkri/webservices/updateProfile.php?oldEmailID=" + App.currentUser.email) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "text/json";
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
    private void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the stream request operation
            Stream postStream = request.EndGetRequestStream(asynchronousResult);
            // Create the post data
            string postData = JsonConvert.SerializeObject(edit).ToString();
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();
            //Start the web request
            request.BeginGetResponse(new AsyncCallback(GetResponceStreamCallback), request);
        }
        void GetResponceStreamCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
            using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
            {
                string result = httpWebStreamReader.ReadToEnd();
                stat.Text = result;
            }
        }
