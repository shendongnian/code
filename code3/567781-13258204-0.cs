    private byte[] createPDF(string html, string filename){
            MemoryStream msInput = new MemoryStream(ASCIIEncoding.Default.GetBytes(html));
            MemoryStream msOutput = new MemoryStream();
            string printPDFCSS = Server.MapPath("/content/printPDF.css");
            Document doc = new Document(PageSize.LETTER);
            doc.SetMargins(doc.LeftMargin, doc.RightMargin, 35, 0);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, msOutput);
            doc.Open();
            Dictionary<String, String> substFonts = new Dictionary<String, String>();
            substFonts["Arial Unicode MS"] = "Helvetica";
            CssFilesImpl cssFiles = new CssFilesImpl();
            cssFiles.Add(XMLWorkerHelper.GetCSS(new FileStream(printPDFCSS, FileMode.Open)));
            StyleAttrCSSResolver cssResolver = new StyleAttrCSSResolver(cssFiles);
            HtmlPipelineContext hpc = new HtmlPipelineContext(new CssAppliersImpl(new UnembedFontProvider(XMLWorkerFontProvider.DONTLOOKFORFONTS, substFonts)));
            hpc.SetImageProvider(new ImageProvider(filename));
            hpc.SetAcceptUnknown(true).AutoBookmark(true).SetTagFactory(Tags.GetHtmlTagProcessorFactory());
            HtmlPipeline htmlPipeline = new HtmlPipeline(hpc, new PdfWriterPipeline(doc, pdfWriter));
            IPipeline pipeline = new CssResolverPipeline(cssResolver, htmlPipeline);
            XMLWorker worker = new XMLWorker(pipeline, true);
            XMLParser xmlParse = new XMLParser(true, worker);
            xmlParse.Parse(msInput);
            doc.Close();
            return msOutput.ToArray();
        }
