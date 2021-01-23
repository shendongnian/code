    	var oauth = new OAuth.Manager();
    	oauth["consumer_key"] = Settings.TWITTER_CONSUMER_KEY;
    	oauth["consumer_secret"] = Settings.TWITTER_CONSUMER_SECRET;
    	oauth["token"] = item.AccessToken;
    	oauth["token_secret"] = item.AccessSecret;
    
    	var url = "https://upload.twitter.com/1/statuses/update_with_media.xml";
    	var authzHeader = oauth.GenerateAuthzHeader(url, "POST");
    
    	foreach (var imageName in item.Images.Split('|'))
    	{
    		var fileData = PhotoThubmnailBO.GetThumbnailForImage(imageName, ThumbnailType.FullSize).Photo;
    
    		// this code comes from http://cheesoexamples.codeplex.com/wikipage?title=TweetIt&referringTitle=Home
    		// also see http://stackoverflow.com/questions/7442743/how-does-one-upload-a-photo-to-twitter-with-the-api-function-post-statuses-updat
    		var request = (HttpWebRequest) WebRequest.Create(url);
    
    		request.Method = "POST";
    		request.PreAuthenticate = true;
    		request.AllowWriteStreamBuffering = true;
    		request.Headers.Add("Authorization", authzHeader);
    
    		string boundary = "~~~~~~" +
    						  Guid.NewGuid().ToString().Substring(18).Replace("-", "") +
    						  "~~~~~~";
    
    		var separator = "--" + boundary;
    		var footer = "\r\n" + separator + "--\r\n";
    		string shortFileName = imageName;
    		string fileContentType = GetMimeType(shortFileName);
    		string fileHeader = string.Format("Content-Disposition: file; " +
    										  "name=\"media\"; filename=\"{0}\"",
    										  shortFileName);
    		var encoding = Encoding.GetEncoding("iso-8859-1");
    
    		var contents = new StringBuilder();
    		contents.AppendLine(separator);
    		contents.AppendLine("Content-Disposition: form-data; name=\"status\"");
    		contents.AppendLine();
    		contents.AppendLine(item.UserMessage);
    		contents.AppendLine(separator);
    		contents.AppendLine(fileHeader);
    		contents.AppendLine(string.Format("Content-Type: {0}", fileContentType));
    		contents.AppendLine();
    
    		// actually send the request
    		request.ServicePoint.Expect100Continue = false;
    		request.ContentType = "multipart/form-data; boundary=" + boundary;
    
    		using (var s = request.GetRequestStream())
    		{
    			byte[] bytes = encoding.GetBytes(contents.ToString());
    			s.Write(bytes, 0, bytes.Length);
    			bytes = fileData;
    			s.Write(bytes, 0, bytes.Length);
    			bytes = encoding.GetBytes(footer);
    			s.Write(bytes, 0, bytes.Length);
    		}
    
    		using (var response = (HttpWebResponse) request.GetResponse())
    		{
    			if (response.StatusCode != HttpStatusCode.OK)
    			{
    				throw new Exception(response.StatusDescription);
    			}
    		}
    	}
