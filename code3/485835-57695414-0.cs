    try
    {
        response = (HttpWebResponse)request.GetResponse();
        using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
        {
            responseMessage = streamReader.ReadToEnd();
            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
            response.Close();
        }
    }
    catch(WebException ex)
    {
        using (StreamReader streamReader = new StreamReader(ex.Response.GetResponseStream()))
        {
            responseMessage = streamReader.ReadToEnd();
            File.WriteAllText(@"C:\Users\Paul\Documents\text.txt", responseMessage);
        }
    }
