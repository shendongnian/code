    public ActionResult DisplayPDF()
    {
        byte[] byteArray = GetPdfFromDB();
        
        return new FileContentResult(byteArray, "application/pdf");
    }
