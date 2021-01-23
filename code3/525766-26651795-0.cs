      private void CreatePdfPechkin(string htmlString, string fileName)
            {
                //Transform the HTML into PDF
                var pechkin = Factory.Create(new GlobalConfig()
                .SetMargins(new Margins(100, 50, 100, 100))
                  .SetDocumentTitle("Test document")
                  .SetPaperSize(PaperKind.A4)
                   .SetCopyCount(1)
                               //.SetPaperOrientation(true)
                              // .SetOutputFile("F:/Personal/test.pdf")
                           
                 );
                ObjectConfig oc = new ObjectConfig();
                oc.Footer.SetLeftText("[page]");
                oc.Footer.SetTexts("[page]", "[date]", "[time]");
                oc.Header.SetCenterText("TEST HEADER TEST1");
                oc.Header.SetHtmlContent("<h1>TEST HEADER V2</h1>");
                oc.SetAllowLocalContent(true);
               //// create converter
                //IPechkin ipechkin = new SynchronizedPechkin(pechkin);
    
                // set it up using fluent notation
                var pdf = pechkin.Convert(new ObjectConfig()
                            .SetLoadImages(true).SetZoomFactor(1.5)
                            .SetPrintBackground(true)
                            .SetScreenMediaType(true)
                            .SetCreateExternalLinks(true), htmlString);
             
               //Return the PDF file
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename=test.pdf; size={0}", pdf.Length));
                Response.BinaryWrite(pdf);
                Response.Flush();
                Response.End();
    //            byte[] pdf = new Pechkin.Synchronized.SynchronizedPechkin(
    //new Pechkin.GlobalConfig()).Convert(
    //    new Pechkin.ObjectConfig()
    //   .SetLoadImages(true)
    //   .SetPrintBackground(true)
    //   .SetScreenMediaType(true)
    //   .SetCreateExternalLinks(true), htmlString);
    //            using (FileStream file = System.IO.File.Create(@"F:\Pankaj WorkSpace\"+  fileName))
    //            {
    //                file.Write(pdf, 0, pdf.Length);
    //            }
            }
