    using Microsoft.Win32;
	public IEnumerable<string> RecommendedPrograms(string ext)
	{
		List<string> progs = new List<string>();
		string baseKey = @"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\." + ext;
		using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithList"))
		{
			if (rk != null)
			{
				string mruList = (string)rk.GetValue("MRUList");
				if (mruList != null)
				{
					foreach (char c in mruList.ToString())
					if(rk.GetValue(c.ToString())!=null)
						progs.Add(rk.GetValue(c.ToString()).ToString());
				}
			}
		}
		using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(baseKey + @"\OpenWithProgids"))
		{
			if (rk != null)
			{
				foreach (string item in rk.GetValueNames())
					progs.Add(item);
			}
			//TO DO: Convert ProgID to ProgramName, etc.
		}
		return progs;
	}
