    using (doc)
    {
        StyleSheet styles = new StyleSheet();
        using (PdfWriter writer = PdfWriter.GetInstance(this.doc, new     FileStream(@"Z:\programs\" + pdfName + ".pdf", FileMode.Create)))
        {
            //.....
        }
        doc.CloseDocument();
        doc.Close();
    }
