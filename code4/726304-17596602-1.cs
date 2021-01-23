    private async Task SqlExpressDownloadAsync()
    {
    	string sSource = string.Format("{0}\\{1}", Paths.Settings_Common, "sqlexpr_x64_enu.exe");
    	Debug.WriteLine(sSource);
        Debug.WriteLine("http://www.elexioamp.com/Install/redistributables/sql2008r2express/sqlexpr_x64_enu.exe");
    	if (!System.IO.File.Exists(sSource))
    	{
    		WebClient oWebClient = new WebClient();
    		oWebClient.DownloadProgressChanged += DownloadProgressChanged;
    		oWebClient.DownloadDataCompleted += DownloadComplete;
    		await oWebClient.DownloadFileTaskAsync(new System.Uri("http://www.elexioamp.com/Install/redistributables/sql2008r2express/sqlexpr_x64_enu.exe"), sSource);	
    	}	
    }
