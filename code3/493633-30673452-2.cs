        private static void MoveImagesToPage2(ICollection imagesToBePrintedOnSeparatePages, IDocListener pdfDocument, PdfWriter pdfWriter)
        {
            pdfDocument.NewPage(); // required - http://itextpdf.com/examples/iia.php?id=98
            var numberOfPages = pdfWriter.ReorderPages(null);
            var newOrder = new int[numberOfPages];
            newOrder[0] = 1; // Keep page 1 as page 1
            var i = 1;
            for (var j = imagesToBePrintedOnSeparatePages.Count - 1; 0 <= j; j--)
            {
                newOrder[i] = numberOfPages - j;
                i++;
            }
            for (; i < numberOfPages; i++)
            {
                newOrder[i] = i - (imagesToBePrintedOnSeparatePages.Count - 1);
            }
            pdfWriter.ReorderPages(newOrder);
        }
