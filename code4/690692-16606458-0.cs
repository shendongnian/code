    public string Send()
    {
        try {
            return "Your string value";
        }
        catch (WebException e) {
            using (WebResponse response = e.Response) { 
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                using (Stream Data = response.GetResponseStream())
                {
                   return new StreamReader(Data).ReadToEnd();
                }
            }
        }
    }
