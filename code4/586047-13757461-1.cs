    public static void RecompressToJpeg(string path, string outputPath)
    {
        using (PdfDocument doc = new PdfDocument(path))
        {
            foreach (PdfImage image in doc.Images)
            {
                // image that is used as mask or image with attached mask are
                // not good candidates for recompression
                if (!image.IsMask && image.Mask == null && (image.Width >= 256 || image.Height >= 256))
                    image.Scale(0.5, PdfImageCompression.Jpeg, 65);
            }
    
            doc.Save(outputPath);
        }
    }
