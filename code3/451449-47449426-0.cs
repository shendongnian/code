                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                Paragraph Text = new Paragraph("This is test file"); // hardcode text
                pdfDoc.Add(new Phrase(this.lbl1.Text.Trim())); //from label
                pdfDoc.Add(new Phrase(this.txt1.Text.Trim())); //from textbox
                pdfDoc.Add(Text);
                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
