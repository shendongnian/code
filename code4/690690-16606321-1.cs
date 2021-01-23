    public string Send()
    {
        string text = null; //Define at method scope
        ///some variables           
        try
        {
            ///
        }
        catch (WebException e)
        {
            using (WebResponse response = e.Response)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                using (Stream Data = response.GetResponseStream())
                {
                    text = new StreamReader(Data).ReadToEnd();
                }
            }
        }
        return text;
    }
