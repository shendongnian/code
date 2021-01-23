    public void Response_Completed(IAsyncResult result)
    {
        this.Invoke((MethodInvoker)delegate
        {
             HttpWebRequest request = (HttpWebRequest)result.AsyncState;
             HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
             using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
             {
                JObject rootObject = JObject.Load(new JsonTextReader(streamReader));
                string tracknum = trackid.Text; // Invalid cross-thread access exception
                string source = rootObject[tracknum]["source"].ToString();
             }
        });
    }
