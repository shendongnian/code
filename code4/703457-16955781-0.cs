    string pdfTemplate = Server.MapPath("~/PDF/") + "invoiceTest.pdf";
    string newFile = Server.MapPath("~/PDF/") + "invoice" + 1 + ".pdf";
    
    using (FileStream ms = new FileStream(Server.MapPath("~/PDF/") + "invoice" + 1 + ".pdf", FileMode.Create))
    using (FileStream formFile = new FileStream(Server.MapPath("~/PDF/") + "invoiceTest.pdf", FileMode.Open))
    {
        PdfReader reader = new PdfReader(formFile);
        // YOU DON'T NEED A DOCUMENT OBJECT HERE!
        // READ THE DOCUMENTATION!!!
        PdfStamper outStamper = new PdfStamper(reader, ms);
        AcroFields fields = outStamper.AcroFields;
        BaseFont bfComic = BaseFont.CreateFont(Server.MapPath("~/PDF/") + "trebuc.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        // UPDATE THE FORM FIELDS
        fields.SetFieldProperty("txtContragentName", "textfont", bfComic, null);
        fields.SetField("txtContragentName", "Фрея");
        fields.SetFieldProperty("txtContragentCode", "textfont", bfComic, null);
        fields.SetField("txtContragentCode", "DGB34TT");
        fields.SetFieldProperty("txtDateCreated", "textfont", bfComic, null);
        fields.SetField("txtDateCreated", "03.06.2013");
        outStamper.Close();
    }
    using (FileStream ms = new FileStream(Server.MapPath("~/PDF/") + "invoice" + 2 + ".pdf", FileMode.Create))
    using (FileStream formFile = new FileStream(Server.MapPath("~/PDF/") + "invoice" + 1 + ".pdf", FileMode.Open))
    {
        PdfReader reader = new PdfReader(formFile);
        // I'm adding extra parameters to change the margins so that they match what you had when you defined your ColumnText object
        using (Document document = new Document(reader.GetPageSizeWithRotation(1), 40, 40, 20, 20))
        {
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            document.Open();
            // HEADERS ARE ADDED WITH PAGE EVENTS!!!
            // PLEASE READ ABOUT PAGE EVENTS IF YOU NEED PAGE HEADERS
            string text = @"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse blandit blandit turpis. Nam in lectus ut dolor consectetuer bibendum. Morbi neque ipsum, laoreet id; dignissim et, viverra id, mauris. Nulla mauris elit, consectetuer sit amet, accumsan eget, congue ac, libero. Vivamus suscipit. Nunc dignissim consectetuer lectus. Fusce elit nisi; commodo non, facilisis quis, hendrerit eu, dolor? Suspendisse eleifend nisi ut magna. Phasellus id lectus! Vivamus laoreet enim et dolor. Integer arcu mauris, ultricies vel, porta quis, venenatis at, libero. Donec nibh est, adipiscing et, ullamcorper vitae, placerat at, diam. Integer ac turpis vel ligula rutrum auctor! Morbi egestas erat sit amet diam. Ut ut ipsum? Aliquam non sem. Nulla risus eros, mollis quis, blandit ut; luctus eget, urna. Vestibulum vestibulum dapibus erat. Proin egestas leo a metus?";
            BaseFont bfComic = BaseFont.CreateFont(Server.MapPath("~/PDF/") + "trebuc.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font font = new Font(bfComic, 12);
            PdfPTable table = new PdfPTable(10);
            // The next line doesn't make sense if the width percentage is 100%
            // table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.WidthPercentage = 100;
            PdfPCell cell1 = new PdfPCell(new Phrase("ДАТА", new Font(bfComic, 10f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1, VerticalAlignment = 2 };
            cell1.BackgroundColor = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#808080"));
            PdfPCell cell2 = new PdfPCell(new Phrase("Header spanning 3 columns", new Font(Font.NORMAL, 10f, Font.NORMAL, BaseColor.WHITE))) { HorizontalAlignment = 1 };
            cell2.BackgroundColor = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#808080"));
            table.AddCell(cell1);
            table.AddCell(cell2);
            //dump data to be set
            #region dump data
            for (int i = 0; i < 100; i++)
            {
                table.AddCell("Col 1 Row 1");
            }
            #endregion
            float[] widths = new float[] { 200f, 200f, 200f, 200f, 100f, 100f, 100f, 100f, 100f, 100f };
            table.SetWidths(widths);
            table.CompleteRow(); //Added - table won't add the final row if its cells are incomplete - safe to have it ending a table
            document.Add(table);
        }
    }
