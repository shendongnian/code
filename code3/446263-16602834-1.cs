    private void GetAllHyperlinksFromPDFDocument(string pdfFilePath)
    {
        string linkTextBuilder = "";
        string linkReferenceBuilder = "";
        PdfDictionary PageDictionary = default(PdfDictionary);
        PdfArray Annots = default(PdfArray);
        PdfReader R = new PdfReader(pdfFilePath);
        List<BinaryHyperlink> ret = new List<BinaryHyperlink>();
        //Loop through each page
        for (int i = 1; i <= R.NumberOfPages; i++)
        {
            //Get the current page
            PageDictionary = R.GetPageN(i);
    
            //Get all of the annotations for the current page
            Annots = PageDictionary.GetAsArray(PdfName.ANNOTS);
    
            //Make sure we have something
            if ((Annots == null) || (Annots.Length == 0))
                continue;
    
            //Loop through each annotation
    
            foreach (PdfObject A in Annots.ArrayList)
            {
                //Convert the itext-specific object as a generic PDF object
                PdfDictionary AnnotationDictionary = (PdfDictionary)PdfReader.GetPdfObject(A);
    
                //Make sure this annotation has a link
                if (!AnnotationDictionary.Get(PdfName.SUBTYPE).Equals(PdfName.LINK))
                    continue;
    
                //Make sure this annotation has an ACTION
                if (AnnotationDictionary.Get(PdfName.A) == null)
                    continue;
    
                //Get the ACTION for the current annotation
                PdfDictionary AnnotationAction = (PdfDictionary)AnnotationDictionary.GetAsDict(PdfName.A);
                if (AnnotationAction.Get(PdfName.S).Equals(PdfName.URI))
                {
                    //Get action link URL : linkReferenceBuilder
                    PdfString Link = AnnotationAction.GetAsString(PdfName.URI);
                    if (Link != null)
                        linkReferenceBuilder = Link.ToString();
    
                    //Get action link text : linkTextBuilder
                    var LinkLocation = AnnotationDictionary.GetAsArray(PdfName.RECT);
                    List<string> linestringlist = new List<string>();
                    iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(((PdfNumber)LinkLocation[0]).FloatValue, ((PdfNumber)LinkLocation[1]).FloatValue, ((PdfNumber)LinkLocation[2]).FloatValue, ((PdfNumber)LinkLocation[3]).FloatValue);
                    RenderFilter[] renderFilter = new RenderFilter[1];
                    renderFilter[0] = new RegionTextRenderFilter(rect);
                    ITextExtractionStrategy textExtractionStrategy = new FilteredTextRenderListener(new LocationTextExtractionStrategy(), renderFilter);
                    linkTextBuilder = PdfTextExtractor.GetTextFromPage(R, i, textExtractionStrategy).Trim();
                }
            }
        }
    }
