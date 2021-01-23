    public ActionResult getPdfCheckBoxList(String username)
    {
        var service = new MethodService();
        var list = getPDFFileNames(username)
            .Select(x => new PDFCheckBoxList 
            { 
                check = false, 
                Id = x 
            })
            .ToList();
        return PartialView("_checkboxlist", list);
    }
