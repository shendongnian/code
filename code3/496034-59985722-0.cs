			byte[] bodyBytes;
			try
			{
				string body = BodyFormatter.CreateBody(loggingEvent, _parameters);
				bodyBytes = Encoding.UTF8.GetBytes(body);
			}
			catch (Exception e)
			{
				ErrorHandler.Error("Failed to create body", e);
				return;
			}
			HttpWebRequest request = BuildRequest();
			request.BeginGetRequestStream(r =>
			{
				try
				{
					using (Stream stream = request.EndGetRequestStream(r))
					{
						stream.BeginWrite(bodyBytes, 0, bodyBytes.Length, c =>
						{
							try
							{
								stream.EndWrite(c);
								request.BeginGetResponse(a =>
								{
									try
									{
										var response = request.EndGetResponse(a);
										if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
											ErrorHandler.Error("Got failed response: " + ((HttpWebResponse)response).StatusDescription);
										response.Close();
									}
									catch (Exception e)
									{
										ErrorHandler.Error("Failed to get response", e);
									}
								}, null);
							}
							catch (Exception e)
							{
								ErrorHandler.Error("Failed to write", e);
							}
						}, null);
					}
				}
				catch (Exception e)
				{
					ErrorHandler.Error("Failed to connect", e);
				}
			}, null);
		}
