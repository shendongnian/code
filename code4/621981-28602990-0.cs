    public ActionResult DownloadFile(int id)
    {
    	using (var db = new DbContext())
    	{
    		var data =
    			db.Documents.FirstOrDefault(m => m.ID == id);
    		if (data == null) return HttpNotFound();
    		Response.AppendHeader("content-disposition", "inline; filename=filename.pdf");
    		return new FileStreamResult(new MemoryStream(data.Fisier.ToArray()), "application/pdf");
    	}
    }
