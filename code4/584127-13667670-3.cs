    [HttpPost]
    public ActionResult Import(HttpPostedFileBase attachment)
    {
        var wcfClient = new ImportFileWcfClient();
        wcfClient.FileImport(attachment.InputStream);
    }
