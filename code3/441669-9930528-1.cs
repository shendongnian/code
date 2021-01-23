		static void Main(string[] args) {
			MappedDriveResolver mdr = new MappedDriveResolver();
			string logfile;
			string path = @"I:\";
			string[] files;
			// Write out "log" file to where this is running from
			logfile = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
			logfile = Path.Combine(logfile, "log.txt");
			
			using (StreamWriter sw = new StreamWriter(logfile, true)) {
				try {
					sw.WriteLine("Checking path " + path);
					if (mdr.isNetworkDrive(path)) {
						sw.WriteLine("Network Drive: Yes");
					} else {
						sw.WriteLine("Network Drive: No");
					}
				} catch (Exception ex) {
					sw.WriteLine("Exception: " + ex.Message);
				}
				try {
					sw.WriteLine("Resolve path " + path);
					string newpath = mdr.ResolveToUNC(path);
					sw.WriteLine("Resolved path " + newpath);
				} catch (Exception ex) {
					sw.WriteLine("Exception: " + ex.Message);
				}
				try {
					sw.WriteLine("Get file list from " + path);
					files = Directory.GetFiles(path);
					if (files == null || files.Length == 0) {
						sw.WriteLine("No files found");
					} else {
						sw.WriteLine(string.Format("Found {0} files.", files.Length));
					}
				} catch (Exception ex) {
					sw.WriteLine("Exception: " + ex.Message);
				}
				sw.Flush();
				sw.Close();
			}
		}
