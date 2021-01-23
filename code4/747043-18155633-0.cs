    [OutputCache(Duration = 3600, VaryByParam = "id")]
    public ActionResult GetImage(int Id)
    {
        // 1. provide connection to entity framework
        var dbc = new DatabaseContext();
        var item = dbc.FindItem(Id);// call to get the image from EF (2)
        var ms = new MemoryStream(tem.ImageByte);    
        FileStreamResult result = new FileStreamResult(ms, "image/png");
        result.FileDownloadName = item.ImageName; // or item.Id or something (3)
        return result;
    }
