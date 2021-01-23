    ZipFile zipnew = new ZipFile(forgeFile);
	ZipFile zipold = new ZipFile(zFile);
	using(zipnew) {
		// Loop through each entry in the zip file
		foreach(ZipEntry zenew in zipnew) {
			string flna = zenew.FileName;
			// Create a new memory stream for extracted files
			var ms = new MemoryStream();
			// Extract entry into the memory stream
			zenew.Extract(ms);
			ms.Seek(0, SeekOrigin.Begin); // Rewind the memory stream
			using(zipold) {
				// Remove existing entry first
				try {
					zipold.RemoveEntry(flna);
					zipold.Save();
				}
				catch (System.Exception ex) {} // Ignore if there is nothing found
				// Add in the new entry
				var zn = zipold.AddEntry(flna, ms);
				zipold.Save(); // Save the zip file with the newly added file
				ms.Dispose(); // Dispose of the stream so resources are released
			}
		}
		zipnew.Dispose(); // Close the zip file
	}
