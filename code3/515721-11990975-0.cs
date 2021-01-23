	/// <summary>
	/// Determines if WIF is installed on the machine.
	/// </summary>
	public static class WifDetector
	{
		/// <summary>
		/// Gets a value indicating that WIF appears to be installed.
		/// </summary>
		public static bool WifInstalled { get; private set; }
		static WifDetector()
		{
			WifInstalled = IsWifInstalled();
		}
		private static bool IsWifInstalled()
		{
			try
			{
				//return File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
				//								  "Reference Assemblies\\Microsoft\\Windows Identity Foundation\\v3.5\\Microsoft.IdentityModel.dll"));
				//The registry approach seems simpler.
				using( var registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows Identity Foundation") ?? 
										 Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows Identity Foundation") )
				{
					return registryKey != null;
				}
			}
			catch
			{
				//if we don't have permissions or something, this probably isn't a developer machine, hopefully the server admins will figure out the pre-reqs.
				return true;
			}
		}
	}
