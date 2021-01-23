    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        using (MemoryStream stream = new MemoryStream())
        {
            Chart1.SaveImage(stream, ChartImageFormat.Png);
            iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
            chartImage.ScaleToFit(822f, 10000f); // 822 instead of 842 because I have 20f padding (10 + 10) at first line            
            int pageNbr = Convert.ToInt16(Math.Truncate(chartImage.ScaledHeight / 595));
            int p = 0;
            if (chartImage.ScaledHeight % 595 == 0)
                p = pageNbr;
            else
                p = pageNbr + 1;
            for (int i = 1; i <= p; i++)
            {
                pdfDoc.NewPage();
                chartImage.SetAbsolutePosition(10, -(p-i)*595);
                pdfDoc.Add(chartImage);
                
            }
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Chart.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();
        }
