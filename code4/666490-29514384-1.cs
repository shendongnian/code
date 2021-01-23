    public ActionResult DownloadFile() {
        var tempFile = Path.GetTempFileName();
        //do your file processing here...
        //For example: generate a pdf file
        return new FilePathAutoDeleteResult(tempFile, "application/pdf")
        {
			FileDownloadName = "Awesome pdf file.pdf"
		};
    }
