        /// <summary>
        /// Return a detailed directory listing, and also download datetime stamps if specified
        /// </summary>
		/// <param name="directory">Directory to list, e.g. /pub/etc</param>
		/// <param name="doDateTimeStamp">Boolean: set to True to download the datetime stamp for files</param>
		/// <returns>An FTPDirectory object</returns>
		public FTPdirectory ListDirectoryDetail(string directory, bool doDateTimeStamp)
		{
			System.Net.FtpWebRequest ftp = GetRequest(GetDirectory(directory));
			// Set request to do simple list
			ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectoryDetails;
			string str = GetStringResponse(ftp);
			// replace CRLF to CR, remove last instance
			str = str.Replace("\r\n", "\r").TrimEnd('\r');
			// split the string into a list
			FTPdirectory dir = new FTPdirectory(str, _lastDirectory);
			// download timestamps if requested
			if (doDateTimeStamp)
			{
				foreach (FTPfileInfo fi in dir)
				{
					fi.FileDateTime = this.GetDateTimestamp(fi);
				}
			}
			return dir;
		}
		
        /// <summary>
		/// Obtain datetimestamp for remote file
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public DateTime GetDateTimestamp(string filename)
		{
			string path;
			if (filename.Contains("/"))
			{
				path = AdjustDir(filename);
			}
			else
			{
				path = this.CurrentDirectory + filename;
			}
			string URI = this.Hostname + path;
			FtpWebRequest ftp = GetRequest(URI);
			ftp.Method = WebRequestMethods.Ftp.GetDateTimestamp;
			return this.GetLastModified(ftp);
		}
