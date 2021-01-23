    <img src=" @{Html.RenderAction("RenderMemberImage", "Home", new { @picId = x.Id });}" />
    [HttpGet]
    public FileContentResult RenderMemberImage(Guid picId)
    {
        var pic = new Models.Picture(picId);//or however you get your data out of the DB
        return new FileContentResult(pic.ThumbnailData , "mime/jpeg");
    }
