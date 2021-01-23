    public ActionResult Coupons(string file)
    {
        Response.AddHeader("Content-Disposition", "inline; filename=" + file);
        Response.ContentType = "application/pdf";
        AzureStorage.DownloadFile(file, Response.OutputStream);//second parameters asks for a 'Stream', you can use whatever stream you want here, just put it in the Response.OutputStream
        return new EmptyResult();
    }
