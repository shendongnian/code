    public virtual ActionResult RenderToString()
    {
        string html = RenderRazorViewToString(MVC.Markets.Views._RenderToString);
        html = new StringBuilder(html)
            .Replace("\n","")
            .Replace("\r","")
            .Replace("\t","")
            .ToString();
        return Json(new { html = html }, JsonRequestBehavior.AllowGet);
    }
