    public ActionResult ViewPDF()
    {
          string cusomtSwitches = string.Format("--print-media-type --allow {0} --footer-html {0} --footer-spacing -10",
                    Url.Action("Footer", "Document", new { area = ""}, "https"));
    
    
         return new ViewAsPdf("MyPDF.cshtml", model)
                    {
                        FileName = "MyPDF.pdf",
                        CustomSwitches = customSwitches
                    };
    }
    [AllowAnonymous]
    public ActionResult Footer()
    {
        return View();
    }
