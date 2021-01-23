    using System;
    using System.Drawing;
    using Spire.Pdf;
    namespace PDFDecrypt
    {
        class Decrypt
        {
            static void Main(string[] args)
            {
                //Create Document
                String encryptedPdf = @"D:\work\My Documents\Encryption.pdf";
                PdfDocument doc = new PdfDocument(encryptedPdf, "123456");
     
                //Extract Image
                Image image = doc.Pages[0].ImagesInfo[0].Image;
     
                doc.Close();
     
                //Save
                image.Save("EmployeeInfo.png", System.Drawing.Imaging.ImageFormat.Png);
     
                //Launch
                System.Diagnostics.Process.Start("EmployeeInfo.png");
            }
        }
    }
