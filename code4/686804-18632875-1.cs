        private void ReadWebRequestCallBack(IAsyncResult callBackResult)
        {
            var myRequest = (HttpWebRequest)callBackResult.AsyncState;
            if (myRequest != null)
            {
                try
                {
                    HttpWebResponse response = (HttpWebResponse)myRequest.EndGetResponse(callBackResult);
                    Dispatcher.BeginInvoke(delegate() { txtContent.Text = response.StatusCode.ToString(); });
                }
                catch (WebException ex)
                {
                    Dispatcher.BeginInvoke(delegate() { txtContent.Text = ex.Message; });
                }
            }
        }
