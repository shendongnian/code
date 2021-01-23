        private System.IO.Stream GetBinaryDataStream(string nameToPrint, string functionToPrint)
        {
            return new System.IO.MemoryStream(CreateImageForSignatureLine(nameToPrint, functionToPrint));
        }
        private byte[] CreateImageForSignatureLine(string nameToPrint, string functionToPrint)
        {
            using (Image img = new Bitmap(My.Resources.SignatureLineEmpty))
            {
                if (!string.IsNullOrEmpty(nameToPrint))
                {
                    DrawNameOnImage(img, nameToPrint);
                }
                if (!string.IsNullOrEmpty(functionToPrint))
                {
                    DrawFunctionOnImage(img, functionToPrint);
                }
                DrawFunctionOnImage(img, functionToPrint);
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    return ms.ToArray();
                }
            }
        }
        private void DrawNameOnImage(Image img, string nameToPrint)
        {
            DrawOnSignature(img, nameToPrint, 7, 80);
        }
        private void DrawFunctionOnImage(Image img, string functionToPrint)
        {
            DrawOnSignature(img, functionToPrint, 7, 96);
        }
        private void DrawOnSignature(Image img, string text, int x, int y)
        {
            using (System.Drawing.Font font = new System.Drawing.Font(System.Drawing.FontFamily.GenericSansSerif, 8))
            {
                using (Graphics drawing = Graphics.FromImage(img))
                {
                    Brush textBrush = new SolidBrush(System.Drawing.Color.Black);
                    drawing.DrawString(text, font, textBrush, x, y);
                    drawing.Save();
                }
            }
        }
