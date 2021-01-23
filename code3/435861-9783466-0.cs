    using ICSharpCode.SharpZipLib.Zip;
    
    // This will accumulate each of the files named in the fileList into a zip file,
    // and stream it to the browser.
    // This approach writes directly to the Response OutputStream.
    // The browser starts to receive data immediately which should avoid timeout problems.
    // This also avoids an intermediate memorystream, saving memory on large files.
    //
    private void DownloadZipToBrowser(List <string> zipFileList) 
    {
    	Response.ContentType = "application/zip";
    	// If the browser is receiving a mangled zipfile, IIS Compression may cause this problem. Some members have found that
    	//    Response.ContentType = "application/octet-stream"     has solved this. May be specific to Internet Explorer.
    
    	Response.AppendHeader("content-disposition", "attachment; filename=\"Download.zip\"");
    	response.CacheControl = "Private";
    	response.Cache.SetExpires(DateTime.Now.AddMinutes(3)); // or put a timestamp in the filename in the content-disposition
    
    	byte[] buffer = new byte[4096];
    
    	ZipOutputStream zipOutputStream = new ZipOutputStream(Response.OutputStream);
    	zipOutputStream.SetLevel(3); //0-9, 9 being the highest level of compression
    
    	foreach (string fileName in zipFileList) {
    
    		Stream fs = File.OpenRead(fileName);	// or any suitable inputstream
    
    		ZipEntry entry = new ZipEntry(ZipEntry.CleanName(fileName));
    		entry.Size = fs.Length;
    		// Setting the Size provides WinXP built-in extractor compatibility,
    		//  but if not available, you can set zipOutputStream.UseZip64 = UseZip64.Off instead.
    
    		zipOutputStream.PutNextEntry(entry);
    
    		int count = fs.Read(buffer, 0, buffer.Length);
    		while (count > 0) {
    			zipOutputStream.Write(buffer, 0, count);
    			count = fs.Read(buffer, 0, buffer.Length);
    			if (!Response.IsClientConnected) {
    				break;
    			}
    			Response.Flush();
    		}
    		fs.Close();
    	}
    	zipOutputStream.Close();
    
    	Response.Flush();
    	Response.End(); 
    }
