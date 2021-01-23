    private static List<string> allowedExtensions = new List<string>(new string[] {
	".xls",
	".xlsx"
    });
    protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
    	if (e.state == AjaxControlToolkit.AsyncFileUploadState.Success) {
    		string fileExt = System.IO.Path.GetExtension(e.filename);
    		if (allowedExtensions.Contains(fileExt)) {
    			string fileName = System.IO.Path.GetFileName(e.filename);
    			string dir = Server.MapPath("upload_excel/");
    			string path = Path.Combine(dir, fileName);
    			AsyncFileUpload1.PostedFile.SaveAs(path);
    			AsyncFileUpload1.FileContent.Close();
    		} else {
    			// wrong extension
    		}
    	} else {
    		// log and show error
    	}
    }
