    try
    {
       HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
        return sr.ReadToEnd();
    }
    catch (WebException webEx)
    {
        //If you want only 404, some logic here
        //if (((HttpWebResponse)webEx.Response).StatusCode == HttpStatusCode.NotFound)
        //{
        //}
        //else
        //{
        //      throw;
        //
        //webEx.Status;
    }
