            WebRequest client = WebRequest.Create("http://api.worldweatheronline.com/free/v1/weather.ashx?q=London&format=json&num_of_days=5&key=jdbcn8yuwebwybxjpqzzxyhy");
            client.ContentType = "application/x-www-form-urlencoded";
            client.Method = "POST";
            client.BeginGetResponse(ReadWebRequestCallBack, client);
        }
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
