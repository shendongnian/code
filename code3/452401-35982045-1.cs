    bool IsExternalServiceRunning
        {
            get
            {
                bool isRunning = false;
                try
                {
                    var endpoint = new ServiceClient();
                    var serviceUri  = endpoint.Endpoint.Address.Uri;
                    var request = (HttpWebRequest)WebRequest.Create(serviceUri);
                    request.Timeout = 1000000;
                    var response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                        isRunning = true;
                }
                #region
                catch (Exception ex)
                {
                    // Handle error
                }
                #endregion
                return isRunning;
            }
        }
