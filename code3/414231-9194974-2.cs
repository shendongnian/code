        public class ImageCreator : IImageCreator
        {
            public Image CreatePreviewImg(string value, int fontSize, int x, int y)
            {
                // Iniziate barcode font     
                PrivateFontCollection private_fonts = new PrivateFontCollection();
                private_fonts.AddFontFile("FREE3OF9.TTF");
                //Image size A4 at 300dpi     
                Bitmap bm = new Bitmap(width, height);
                bm.SetResolution(300, 300);
                // Create rectangle for the canvas     
                RectangleF rectBg = new RectangleF(0, 0, width, height);
                // Load fonts     
                Font bcFont = new Font(private_fonts.Families[0], fontSize, FontStyle.Regular, GraphicsUnit.Point);
                Font valueFont = new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point);
                // Set StringFormat for the text value     
                StringFormat sfValue = new StringFormat();
                sfValue.LineAlignment = StringAlignment.Far;
                sfValue.Alignment = StringAlignment.Center;
                // Set StringFormat for the barcode string     
                StringFormat sfBarcode = StringFormat.GenericTypographic;
                sfBarcode.FormatFlags = StringFormatFlags.NoClip;
                using (Graphics g = Graphics.FromImage(bm))
                {
                    // Create rectangle to place the barcode and text     
                    SizeF bcStringSize = g.MeasureString("*" + value + "*", bcFont);
                    SizeF valueSize = g.MeasureString(value, valueFont);
                    RectangleF recText = new RectangleF(x, y, (float)MeasureDisplayStringWidth(g, "*" + value + "*", bcFont), (float)(bcStringSize.Height + valueSize.Height));
                    // Drawing the barcode and text     
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.TextRenderingHint = TextRenderingHint.AntiAlias;
                    g.FillRectangle(new SolidBrush(Color.White), rectBg);
                    g.DrawString("*" + value + "*", bcFont, new SolidBrush(Color.Black), recText, sfBarcode);
                    g.DrawString(value, valueFont, new SolidBrush(Color.Black), recText, sfValue);
                }
                return bm;
            }
        }
