	public bool AddAttachments(string issueKey, IEnumerable<string> filePaths)
    {
        string restUrl = Jira.FormatRestUrl(m_JiraId, true);
        string issueLinkUrl = String.Format("{0}/issue/{1}/attachments", restUrl, issueKey);
        var filesToUpload = new List<FileInfo>();
        foreach (var filePath in filePaths)
        {
            if (!File.Exists(filePath))
            {
                Jira.LogError("File '{0}' doesn't exist", filePath);
                return false;
            }
            var file = new FileInfo(filePath);
            if (file.Length > 10485760) // TODO Get Actual Limit
            {
                Jira.LogError("Attachment too large");
                return false;
                    
            }
            filesToUpload.Add(file);
        }
        if (filesToUpload.Count <= 0)
        {
            Jira.LogWarning("No file to Upload");
            return false;
        }
        return PostMultiPart(issueLinkUrl, filesToUpload);
    }
	
	private Boolean PostMultiPart(string restUrl, IEnumerable<FileInfo> filePaths)
	{
	    HttpWebResponse response = null;
	    HttpWebRequest request = null;
	
	    try
	    {
	        var boundary = string.Format("----------{0:N}", Guid.NewGuid());
	        var content = new MemoryStream();
	        var writer = new StreamWriter(content);
	
	        foreach (var filePath in filePaths)
	        {
	            var fs = new FileStream(filePath.FullName, FileMode.Open, FileAccess.Read);
	            var data = new byte[fs.Length];
	            fs.Read(data, 0, data.Length);
	            fs.Close();
	
	            writer.WriteLine("--{0}", boundary);
	            writer.WriteLine("Content-Disposition: form-data; name=\"file\"; filename=\"{0}\"", filePath.Name);
	            writer.WriteLine("Content-Type: application/octet-stream");
	            writer.WriteLine();
	            writer.Flush();
	
	            content.Write(data, 0, data.Length);
	
	            writer.WriteLine();
	        }
	
	        writer.WriteLine("--" + boundary + "--");
	        writer.Flush();
	        content.Seek(0, SeekOrigin.Begin);
	
	        request = WebRequest.Create(restUrl) as HttpWebRequest;
	        if (request == null)
	        {
	            Jira.LogError("Unable to create REST query: {0}", restUrl);
	            return false;
	        }
	
	        request.Method = "POST";
	        request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
	        request.Accept = "application/json";
	        request.Headers.Add("Authorization", "Basic " + m_EncodedCredential);
	        request.Headers.Add("X-Atlassian-Token", "nocheck");
	        request.ContentLength = content.Length;
	
	        using (Stream requestStream = request.GetRequestStream())
	        {
	            content.WriteTo(requestStream);
	            requestStream.Close();
	        }
	
	        using (response = request.GetResponse() as HttpWebResponse)
	        {
	            if (response.StatusCode != HttpStatusCode.OK)
	            {
	                var reader = new StreamReader(response.GetResponseStream());
	                Jira.LogError("The server returned '{0}'\n{1}", response.StatusCode, reader.ReadToEnd());
	                return false;
	            }
	
	            return true;
	        }
	    }
	    catch (WebException wex)
	    {
	        if (wex.Response != null)
	        {
	            using (var errorResponse = (HttpWebResponse)wex.Response)
	            {
	                var reader = new StreamReader(errorResponse.GetResponseStream());
	                Jira.LogError("The server returned '{0}'\n{1}).", errorResponse.StatusCode, reader.ReadToEnd());
	            }
	        }
	
	        if (request != null)
	        {
	            request.Abort();
	        }
	
	        return false;
	    }
	    finally
	    {
	        if (response != null)
	        {
	            response.Close();
	        }
	    }
	}
