    byte[] bytes = Encoding.UTF8.GetBytes(requestXml.ToString());
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
    request.Method = "POST";
    request.ContentType = "text/xml";
    try
    {
        using (Stream uploadStream = await request.GetRequestStreamAsync())
        {
            await uploadStream.WriteAsync(bytes, 0, bytes.Length);
            await uploadStream.FlushAsync();
        }
        using (HttpWebResponse response = (HttpWebResponse) await request.GetRequestStreamAsync())
        {
            data = ProcessResponse(XmlReader.Create(response.GetResponseStream()));
        }
    }
    catch (Exception e)
    {
        // Exception
    }
