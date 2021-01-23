    using (MemoryStream mStream = frmRptViewer.CryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)) {
        Dictionary<PARAMS, Object> pdfDictionary = new Dictionary<PARAMS, Object>();
        pdfDictionary.Add(PARAMS.TYPE, "PDFSAVE");
        pdfDictionary.Add(PARAMS.PDF, mStream);
        pdfDictionary.Add(PARAMS.JOBNUMB, jobNumTextBox.Text);
        pdfDictionary.Add(PARAMS.LINENUMB, lineNumTextBox.Text);
        DBCall.SavePDF(pdfDictionary);
    
    }
