	public IObservable<string> GetFileReport(string checksum)
	{
		return this.GetResponse(this.FileReportURL,
			new Dictionary<string, string>() { { "resource", checksum }, });
	}
	public IObservable<string> GetURLReport(string url)
	{
		return this.GetResponse(this.URLReportURL,
			new Dictionary<string, string>()
			    { { "resource", url }, { "scan", "1" }, });
	}
	public IObservable<string> SubmitURL(string url)
	{
		return this.GetResponse(this.URLSubmitURL,
			new Dictionary<string, string>() { { "url", url }, });
	}
	public IObservable<string> SubmitFile()
	{
		return this.GetResponse("UNKNOWNURL", new Dictionary<string, string>());
	}
