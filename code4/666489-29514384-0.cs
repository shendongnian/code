    public class FilePathAutoDeleteResult : FilePathResult
    {
	    public FilePathAutoDeleteResult(string fileName, string contentType) : base(fileName, contentType)
	    {
	    }
	    protected override void WriteFile(HttpResponseBase response)
	    {
		    base.WriteFile(response);
		    response.Flush();
		    response.Close();
		    File.Delete(FileName);
	    }
    }
