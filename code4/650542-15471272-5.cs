    [HttpPost]
    public ActionResult Upload(int? chunk, string name)
    {
        var fileUpload = Request.Files[0];
        var uploadPath = Server.MapPath("~/App_Data");
        chunk = chunk ?? 0;
        using (var fs = new FileStream(Path.Combine(uploadPath, name), chunk == 0 ? FileMode.Create : FileMode.Append))
        {
            var buffer = new byte[fileUpload.InputStream.Length];
            fileUpload.InputStream.Read(buffer, 0, buffer.Length);
            fs.Write(buffer, 0, buffer.Length);
        }
        return Json(new { message = "chunk uploaded", name = name });
    }
