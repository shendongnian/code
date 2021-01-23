    [HttpPost]
    public ActionResult Test()
    {
        var file = Request.Files[0] as HttpPostedFile;
        XElement xml = XElement.Load(new System.IO.StreamReader(file.InputStream));
        var test = new MyTest();
        return File(test.RunTest(xml), "text/xml", "testresult.xml");
    }
