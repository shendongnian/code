    public string GetLocalPathForUnc(string uncName)
    {
    	var mapped = Environment.GetLogicalDrives().Select(drive => 
    	{
    		drive = drive.Substring(0,2);
    		var buffer = new StringBuilder(0xff);
    		int length = 0xff;
    		WNetGetConnection(drive, buffer, ref length);
    		return new {Drive = drive, Unc = buffer.ToString()};
    	});
    	var match = mapped
                .Where(ob => 
                     !string.IsNullOrWhiteSpace(ob.Drive) && 
                     !string.IsNullOrWhiteSpace(ob.Unc))
    		.FirstOrDefault(ob => uncName.ToLowerInvariant().StartsWith(ob.Unc.ToLowerInvariant()));
    	return uncName.Replace(match.Unc, match.Drive);
    }
