    public string Send()
    {
        string text = null;
    
        try 
        {
    
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
