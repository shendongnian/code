        byte[] bytesArray = null;
        using (var ms = new MemoryStream())
        {
            using (var document = new Document())
            {
                using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
                {
                    document.Open();
                    using (var strReader = new StringReader(html))
                    {
                        //Set factories
                        HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
                        htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
                        //Set css
                        ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
                        cssResolver.AddCssFile(System.Web.HttpContext.Current.Server.MapPath("~/Content/bootstrap.min.css"), true);
                        //Export
                        IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
                        var worker = new XMLWorker(pipeline, true);
                        var xmlParse = new XMLParser(true, worker);
                        xmlParse.Parse(strReader);
                        xmlParse.Flush();
                    }
                    document.Close();
                }
            }
            bytesArray = ms.ToArray();
        }
        return bytesArray;
