    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;
    using Spire.Pdf;
    
    namespace ExtractImagesFromPDF
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Instantiate an object of Spire.Pdf.PdfDocument
                PdfDocument doc = new PdfDocument();
                //Load a PDF file 
                doc.LoadFromFile("sample.pdf");
                List<Image> ListImage = new List<Image>();
                for (int i = 0; i < doc.Pages.Count; i++)
                {
                    // Get an object of Spire.Pdf.PdfPageBase
                    PdfPageBase page = doc.Pages[i];
                    // Extract images from Spire.Pdf.PdfPageBase
                    Image[] images = page.ExtractImages();
                    if (images != null && images.Length > 0)
                    {
                        ListImage.AddRange(images);
                    }
    
                }
                if (ListImage.Count > 0)
                {
                    for (int i = 0; i < ListImage.Count; i++)
                    {
                        Image image = ListImage[i];
                        image.Save("image" + (i + 1).ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    }
                    System.Diagnostics.Process.Start("image1.png");
                }  
            }
        }
    }
