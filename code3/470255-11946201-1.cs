    //   Required: iTextSharp.dll
    
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using iTextSharp.text.pdf.parser;
    using Dotnet = System.Drawing.Image;
    using iTextSharp.text.pdf;
    
    namespace PDF_Parsing {
        partial class ExtractPdfImage
        {
            string imgPath = @"c:\extractedImg.png";
            private void ExtractImage(string pdfFile)
            {
                const int pageNumber = 1;
                PdfReader pdf = new PdfReader(pdfFile);
                PdfDictionary pg = pdf.GetPageN(pageNumber);
                PdfDictionary res =               (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
                PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
                foreach (PdfName name in xobj.Keys)
                {
                    PdfObject obj = xobj.Get(name);
                    if (obj.IsIndirect())
                    {
                        PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                        string width = tg.Get(PdfName.WIDTH).ToString();
                        string height = tg.Get(PdfName.HEIGHT).ToString();
                        ImageRenderInfo imgRI = ImageRenderInfo.CreateForXObject(new   Matrix(float.Parse(width), float.Parse(height)),
                            (PRIndirectReference)obj, tg);
                        RenderImage(imgRI);
                    }
                }
            }
    
            private void RenderImage(ImageRenderInfo renderInfo)
            {
                PdfImageObject image = renderInfo.GetImage();
                using (Dotnet dotnetImg = image.GetDrawingImage())
                {
                    if (dotnetImg != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            dotnetImg.Save(ms, ImageFormat.Tiff);
                            Bitmap d = new Bitmap(dotnetImg);
                            d.Save(imgPath);
                        }
                    }
                }
            }
        }
    }
