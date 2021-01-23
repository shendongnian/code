		public static Stream getDataFromHttp(string strUrl)
		{
			Stream strmOutput = null;
			try
			{
				HttpWebRequest request;
				Uri targetUri = new Uri(strUrl);
				request = (HttpWebRequest)HttpWebRequest.Create(targetUri);
				request.Timeout = 5000;
				request.ReadWriteTimeout = 20000;
				request.Method = "Get";
				
				
				request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
				if (request != null)
				{
					request.GetResponse();
					if (request.HaveResponse)
					{
						HttpWebResponse response = (HttpWebResponse)request.GetResponse();
						strmOutput = response.GetResponseStream();
					}
				}
			}
			catch (WebException wex)
			{
			}
			catch (Exception ex)
			{
			}
			return strmOutput;
		}
