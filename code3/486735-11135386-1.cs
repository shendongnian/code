	string HostName = System.Configuration.ConfigurationSettings.AppSettings["HostName"];
	string strUser = System.Configuration.ConfigurationSettings.AppSettings["BasicAuthenticationUser"];
	string strPWD = System.Configuration.ConfigurationSettings.AppSettings["BasicAuthenticationPWD"];
	FtpWebRequest request = (FtpWebRequest)WebRequest.Create(HostName + strFile);
	request.Method = WebRequestMethods.Ftp.DownloadFile;
	request.Credentials = new NetworkCredential(strUser, strPWD);
	request.UsePassive = true;
	request.UseBinary = true;
	request.KeepAlive = false;
	FtpWebResponse response = (FtpWebResponse)request.GetResponse();
	Stream responseStream = response.GetResponseStream();
	Response.ContentType = "application/octet-stream";
	Response.AddHeader("content-disposition", "attachment;filename=" + _AudiobookName + ".zip");
	int read;
	byte[] buffer = new byte[2 * 1024];
	while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
	{
		Response.OutputStream.Write(buffer, 0, read);
		Response.Flush();
	}
	responseStream.Close();
	response.Close();
	Response.Flush();
	Response.End();
