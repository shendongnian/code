    public ActionResult Search()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Search(string searchString)
    {
        var certificate = db.certificate_mst.Where(s => s.CertificateNo.Contains(searchString));
        //OR
        //var certificate = db.certificate_mst.Search(s => s.CertificateNo, searchString));
        return View(certificate);        
    }
