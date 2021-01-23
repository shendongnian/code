    using DiscUtils;
    using DiscUtils.Iso9660;
	void ExtractISO(string ISOName, string ExtractionPath)
	{
		CDReader Reader = new CDReader(File.Open(ISOName, FileMode.Open), true);
		ExtractDirectory(Reader.Root, ExtractionPath + Path.GetFileNameWithoutExtension(ISOName) + "\\", "");
		Reader.Dispose();
	}
	void ExtractDirectory(DiscDirectoryInfo Dinfo, string RootPath, string PathinISO)
	{
		if (!string.IsNullOrWhiteSpace(PathinISO))
		{
			PathinISO += "\\" + Dinfo.Name;
		}
		RootPath += "\\" + Dinfo.Name;
		AppendDirectory(RootPath);
		foreach (DiscDirectoryInfo dinfo in Dinfo.GetDirectories())
		{
			ExtractDirectory(dinfo, RootPath, PathinISO);
		}
		foreach (DiscFileInfo finfo in Dinfo.GetFiles())
		{
			using (Stream FileStr = finfo.OpenRead())
			{
				byte[] Buffer = new byte[FileStr.Length];
				FileStr.Read(Buffer, 0, (int)FileStr.Length);
				using (FileStream Fs = new FileStream(RootPath + "\\" + finfo.Name, FileMode.Create, FileAccess.Write))
				{
					Fs.Write(Buffer, 0, (int)Buffer.Length);
				}
			}
		}
	}
	static void AppendDirectory(string path)
	{
		try
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
		catch (DirectoryNotFoundException Ex)
		{
			AppendDirectory(Path.GetDirectoryName(path));
		}
		catch (PathTooLongException Exx)
		{
			AppendDirectory(Path.GetDirectoryName(path));
		}
	}
