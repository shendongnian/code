        /// <summary>
        /// Copy directory recursive with permissions, overwrite existing
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <param name="destinationFolder"></param>
	    public static void CopyDirectory(string sourceFolder, string destinationFolder)
	    {
            var sourceDirectory = new DirectoryInfo(sourceFolder);
	        if (!sourceDirectory.Exists) throw new DirectoryNotFoundException("Source folder not found: " + sourceFolder);
            var destinationDirectory = !Directory.Exists(destinationFolder) ? Directory.CreateDirectory(destinationFolder) : new DirectoryInfo(destinationFolder);
			
			CopyDirectory(sourceDirectory,destinationDirectory);
        }
		
		public static void CopyDirectory(DirectoryInfo sourceDirectory, DirectoryInfo destinationDirectory)
		{
			if(sourceDirectory == null) throw new ArgumentException("sourceDirectory");
			if(destinationDirectory == null) throw new ArgumentException("destinationDirectory");
			
		    var security = sourceDirectory.GetAccessControl();
            security.SetAccessRuleProtection(true, true);
            destinationDirectory.SetAccessControl(security);
	        var dirsToCopy = sourceDirectory.GetDirectories();
	        foreach (var dirToCopy in dirsToCopy)
	        {
				var destSubDirPath = Path.Combine(destinationDirectory.FullName,dirToCopy.Name);
	            var destinationSubDir = !Directory.Exists(destSubDirPath) ? Directory.CreateDirectory(destSubDirPath) : new DirectoryInfo(destSubDirPath);
				CopyDirectory(dirToCopy,destinationSubDir);
	        }
            var filesToCopy = sourceDirectory.GetFiles();
            foreach (var file in filesToCopy)
            {
				CopyFile(file, destinationDirectory.FullName);
            }
		}
		
		private static void CopyFile(FileInfo file, string destinationDirectory)
		{
			var path = Path.Combine(destinationDirectory, file.Name);
			var fileSecurity = file.GetAccessControl();
			
			fileSecurity.SetAccessRuleProtection(true, true);
			
			file.CopyTo(path, true);
			
			var copiedFile = new FileInfo(path);
			
			copiedFile.SetAccessControl(fileSecurity);
		}
