    public ActionResult PrintPDF(int? selectedSiteRotaId, int selectedSiteId)
    {
        string footer = "--footer-center \"Printed on: " + DateTime.Now.Date.ToString("MM/dd/yyyy") + "  Page: [page]/[toPage]\"" + " --footer-line --footer-font-size \"9\" --footer-spacing 6 --footer-font-name \"calibri light\"";
        return new ActionAsPdf("RenderPDF", new { selectedSiteRotaId = selectedSiteRotaId, selectedSiteId = 7 }) 
        {
            FileName = "PDF_Output.pdf",
            PageOrientation = Orientation.Landscape,
            MinimumFontSize = 10, 
            //PageMargins  = new Margins(5,5,5,5),
            PageSize = Size.A3,
            CustomSwitches = footer
        };
        //var pdfResult = new ActionAsPdf("RenderPDF", new { selectedSiteRotaId = selectedSiteRotaId, selectedSiteId = 7 })
        //{
        //    FileName = "PDF_Output.pdf",
        //    PageOrientation = Orientation.Landscape,
        //    MinimumFontSize = 10
        //};
        //var binary = pdfResult.BuildPdf(this.ControllerContext);
        //return File(binary, "application/pdf");
    }
    public ActionResult RenderPDF(int? selectedSiteRotaId, int selectedSiteId)
    {
        return RedirectToAction("Index", "PrintPDF", new { selectedSiteRotaId = selectedSiteRotaId, selectedSiteId = 7 });
    }
