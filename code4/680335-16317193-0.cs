	private static void Export(string exportPath, string registryPath)
	{ 
		string path = "\""+ exportPath + "\"";
		string key = "\""+ registryPath + "\"";
		Process proc = new Process();
		try
		{
			proc.StartInfo.FileName = "regedit.exe";
			proc.StartInfo.UseShellExecute = false;
			proc = Process.Start("regedit.exe", "/e " + path + " "+ key + "");
			proc.WaitForExit();
		}
		catch (Exception)
		{
			proc.Dispose();
		}
	}
