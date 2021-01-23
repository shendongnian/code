    public ActionResult GetPdf(string filename)
    {
        using (var client = new WebClient())
        {
            var buffer = client.DownloadData("http://foo.com/bar.pdf");
            return File(buffer, "application/pdf", "report1.pdf");
        }
    }
