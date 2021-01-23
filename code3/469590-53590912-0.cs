    [HttpPost]
    public async Task<ActionResult<MopedResponse>> PostAsync(IFormCollection collection)
    {
    
    	string pathTemp = Path.GetTempFileName(); // get the temp file name
    
    	// create or process the word file
    
    	// reopen it for serving
    
    	FileStream merged = new FileStream(pathTemp, FileMode.Open, FileAccess.Read, FileShare.None, 4096, FileOptions.DeleteOnClose);
    
    	System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
    	{
    	    FileName = "parafa.docx",
    	    Inline = true  // false = prompt the user for downloading;  true = browser to try to show the file inline
    	};
    	Response.Headers.Add("Content-Disposition", cd.ToString());
    	Response.Headers.Add("Content-Length", merged.Length.ToString());
    
    	return File(merged, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "mywordFile1.docx");
    
    }
