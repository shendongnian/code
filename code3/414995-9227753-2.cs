    [HttpPost]
    public ActionResult VisualizarCredencial()
    {
        // some id of the pdf
        return Json(new { url = Url.Action("GetPdf", "GerenciarCredenciais", new { id = "123" }) });
    }
    
    public ActionResult GetPdf(int id)
    {
        byte[] pdf = ... 
        return File(pdf, "application/pdf");
    }
