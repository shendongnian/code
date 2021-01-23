     Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.Page.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            string htmlpath =Server.MapPath("~/htmloutput.html");
            if (File.Exists(htmlpath))
            {
                File.Delete(htmlpath);
            }  
              
            File.Create(htmlpath).Dispose();
            using (TextWriter tw = new StreamWriter(htmlpath))
            {
                tw.WriteLine(sw.ToString());
                tw.Close();
            }
            string path = Server.MapPath("~/wkhtmltopdf-page.pdf");
            PdfConvert.ConvertHtmlToPdf(new Codaxy.WkHtmlToPdf.PdfDocument
            {
                Url = htmlpath,
                HeaderLeft = "[title]",
                HeaderRight = "[date] [time]",
                FooterCenter = "Page [page] of [topage]"
            }, new PdfOutput
            {
                
                OutputFilePath = path
                
            });
