    public void CallController()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://yoursite.com/Excel");
            request.Method = "POST";
    
            using (var dataStream = request.GetRequestStream())
            {
                //write your data to the data stream
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.TemporaryRedirect)
                    {
                        //work with the controller response
                    }
                }
            }
        }
    
