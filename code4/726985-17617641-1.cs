    public ActionResult Download()
    {
        return new ZipResult(
            Server.MapPath("~/Files/file1.xml"),
            Server.MapPath("~/Files/file2.xml"),
            Server.MapPath("~/Files/file3.xml")
        );
    }
