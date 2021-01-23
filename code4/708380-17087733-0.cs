    var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf");
    using (var fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
    
                //Create a single column table
                var t = new PdfPTable(1);
    
                //Tell it to fill the page horizontally
                t.WidthPercentage = 100;
    
                //Create a single cell
                var c = new PdfPCell();
    
                //Tell the cell to vertically align in the middle
                c.VerticalAlignment = Element.ALIGN_MIDDLE;
    
                //Tell the cell to fill the page vertically
                c.MinimumHeight = doc.PageSize.Height - (doc.BottomMargin + doc.TopMargin);
    
                //Create a test paragraph
                var p = new Paragraph("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam iaculis sem diam, quis accumsan ipsum venenatis ac. Pellentesque nec gravida tortor. Suspendisse dapibus quis quam sed sollicitudin.");
    
                //Add it a couple of times
                c.AddElement(p);
                c.AddElement(p);
    
                //Add the cell to the paragraph
                t.AddCell(c);
    
                //Add the table to the document
                doc.Add(t);
                doc.Close();
            }
        }
    }
