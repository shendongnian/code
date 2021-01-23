    public ActionResult GetPdf(string fileName)
    {
        var fileStream = new FileStream("~/Content/files/" + fileName, 
                                         FileMode.Open,
                                         FileAccess.Read
                                       );
        var fsResult = new FileStreamResult(fileStream, "application/pdf");
        return fsResult;
    }
