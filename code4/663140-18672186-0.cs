    IAsyncResult requestResult = (IAsyncResult)request.BeginGetRequestStream((rAsyncResult) =>
    {
		try
		{
			using (Stream uploadStream = request.EndGetRequestStream(rAsyncResult))
			{
				try
				{
					uploadStream.Write(bytes, 0, bytes.Length);
					uploadStream.Flush();
				}
				catch (Exception e)
				{
					// Exception handling
				}
				finally
				{
					uploadStream.Dispose();
				}
			}
			IAsyncResult responseResult = (IAsyncResult)request.BeginGetResponse((resAsyncResult) =>
			{
				try
				{
					using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(resAsyncResult))
					{
						try
						{
							data = ProcessResponse(XmlReader.Create(response.GetResponseStream()));
						}
						catch (Exception e)
						{
							// Exception handling
						}
						finally
						{
							response.Dispose();
						}
					}
				}
				catch (WebException e)
				{
					// Exception handling
				}
			}, null);
		}
		catch (Exception ex)
		{
			// Handle the exception as you wish
		}
    }, null);
