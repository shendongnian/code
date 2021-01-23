    [HttpPost]
    public FileResult DownloadInvoice(int id1, int id2)
    {
        //necessary to get the filename in the success of the ajax callback
        HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
        byte[] fileBytes = _service.GetInvoice(id1, id2);
        string fileName = "Invoice.xlsx";
        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
