	WebClient wc = new WebClient();
	try
	{
		wc.Credentials = new NetworkCredential("Administrator", "SomePasword", "SomeDomain");
		byte[] aspx = wc.DownloadData("http://SomeServer/SomeSub/SomeFile.aspx");
	}
	catch (WebException we)
	{
		//Catches any error in the WebClient, including an inability to contact the remote server
	}
	catch (System.Exception ex)
	{
	}
