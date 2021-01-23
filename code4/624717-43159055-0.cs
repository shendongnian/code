            PdfPTable table = new PdfPTable(12);
            table.HeaderRows = 1; /*---->> this property repeats the headers of an iTextSharp PdfPTable on each page */
            table.TotalWidth = 900f;
            table.LockedWidth = true;
            //table.HorizontalAlignment = 0;
            float[] widths = new float[] { 20f, 32f, 13f, 24f, 20f, 20f, 30f, 15f, 15f, 20f, 20f, 60f };
            table.SetWidths(widths);
