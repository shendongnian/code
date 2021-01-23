    System.Drawing.Image image = System.Drawing.Image.FromFile("Your image file path");
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream("image.pdf", FileMode.Create));
                doc.Open();
                iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                doc.Add(pdfImage);
                doc.Close();
