   			using (WebResponse httpResponse = httpRequest.GetResponse())
			{
				if (!httpResponse.ResponseUri.AbsoluteUri.Equals(string.Format("{0}main.htm", url), StringComparison.CurrentCultureIgnoreCase))
				{
					throw new Exception("Log in failed. Check the Username and Password information in the Setting table.");
				}
				var responseStream = httpResponse.GetResponseStream();
				if (null != responseStream)
				{
					var buffer = new byte[8192];
					while (responseStream.Read(buffer, 0, buffer.Length) > 0)
					{
						// Do nothing here.
					}	
				}
				httpResponse.Close();
			}
