			FtpWebRequest request=(FtpWebRequest)FtpWebRequest.Create(path);
			request.Method=WebRequestMethods.Ftp.ListDirectoryDetails;
			List<ftpinfo> files=new List<ftpinfo>();
			
			//request.Proxy = System.Net.WebProxy.GetDefaultProxy();
			//request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Credentials = new NetworkCredential(_username, _password);
			Stream rs=(Stream)request.GetResponse().GetResponseStream();
            OnStatusChange("CONNECTED: " + path, 0, 0);
			StreamReader sr = new StreamReader(rs);
			string strList = sr.ReadToEnd();
			string[] lines=null;
			if (strList.Contains("\r\n"))
			{
				lines=strList.Split(new string[] {"\r\n"},StringSplitOptions.None);
			}
			else if (strList.Contains("\n"))
			{
				lines=strList.Split(new string[] {"\n"},StringSplitOptions.None);
			}
			
			//now decode this string array
            if (lines==null || lines.Length == 0)
                return null;
			
			foreach(string line in lines)
			{
				if (line.Length==0)
					continue;
				//parse line
	        	Match m= GetMatchingRegex(line);
	        	if (m==null) {
	    	        //failed
		            throw new ApplicationException("Unable to parse line: " + line);
	        	}
	        	
	        	ftpinfo item=new ftpinfo();
	    	    item.filename = m.Groups["name"].Value.Trim('\r');
	            item.path = path;
	            item.size = Convert.ToInt64(m.Groups["size"].Value);
	            item.permission = m.Groups["permission"].Value;
	            string _dir = m.Groups["dir"].Value;
	            if(_dir.Length>0  && _dir != "-")
	            {
	                item.fileType = directoryEntryTypes.directory;
	            } 
	            else
	            {
	                item.fileType = directoryEntryTypes.file;
	            }
	
	            try
	            {
	            	item.fileDateTime = DateTime.Parse(m.Groups["timestamp"].Value);
	            }
	            catch
	            {
	                item.fileDateTime = DateTime.MinValue; //null;
	            }
	            
	            files.Add(item);
			}
			
			return files;
