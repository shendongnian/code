        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com/afakepage");
        request.Method = WebRequestMethods.Http.Head;
        try
        {
            using (WebResponse response = request.GetResponse())
            {
                
            }
        }
        catch (WebException e)
        {
            using (WebResponse response = e.Response)
            {
                HttpWebResponse httpResponse = (HttpWebResponse) response;
                MessageBox.Show(httpRespnse.StatusCode.ToString());
            }
        }
