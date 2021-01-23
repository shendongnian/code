    public ActionResult Search(string searchString)
    {
        if (String.IsNullOrEmpty(searchString))
        {
             //Return empty viewModel
             return View();
        }
        var certificate = db.certificate_mst.Where(s => s.CertificateNo.Contains(searchString));
        return View(certificate);
    }
