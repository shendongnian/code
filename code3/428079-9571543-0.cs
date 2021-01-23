	public String WebRequestNavigate(string url)
			{
				StringBuilder sb = new StringBuilder();
				byte[] buf = new byte[8192];
				if (url != "")
				{
					bool ConnectionSucceeded;
					while (!ConnectionSucceeded) {
						HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
						myReq.KeepAlive = false;
						try
						{
							HttpWebResponse resp = (HttpWebResponse)myReq.GetResponse();
							Stream stream = resp.GetResponseStream();
							String test = "";
							int count = 0;
							do
							{
								count = stream.Read(buf, 0, buf.Length);
								if (count != 0)
								{
									test = Encoding.UTF8.GetString(buf, 0, count);
									sb.Append(test);
								}
							}
							while (count > 0);
							stream.Close();
							ConnectionSucceeded = true;
						}
						catch (WebException ex)
						{
						}
					}
				}
				return sb.ToString();
			}
