    var httpRequest = WebRequest.Create(string.Format("baseurl" + "/PostData?id={0}", id));
    httpRequest.Method = "POST";
    httpRequest.ContentType = "application/json";
    httpRequest.ContentLength = data.Length;
    try
    {
        using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
        {
            if (!string.IsNullOrEmpty(data))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
		
		var response = httpRequest.GetResponse();
    }
    catch (Exception)
    {}
