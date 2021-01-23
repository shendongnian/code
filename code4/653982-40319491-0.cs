    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ReportPrepare
    {
        class TextDrawing
        {
            public enum DrawMethod
            {
                AutosizeAccordingToText, // create the smallest bitmap needed to draw the text without word warp
                AutoFitInConstantRectangleWithoutWarp, // draw text with the biggest font possible while not exceeding rectangle dimensions, without word warp
                AutoWarpInConstantRectangle, // draw text in rectangle while performing word warp. font size is a constant input. drawing may exceed bitmap rectangle.
                AutoFitInConstantRectangleWithWarp // draw text with the biggest font possible while not exceeding rectangle dimensions, with word warp
            }
    
            private static void SetGraphicsHighQualityForTextRendering(Graphics g)
            {
                // The smoothing mode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing). One exception is that path gradient brushes do not obey the smoothing mode. Areas filled using a PathGradientBrush are rendered the same way (aliased) regardless of the SmoothingMode property.
                g.SmoothingMode = SmoothingMode.AntiAlias;
    
                // The interpolation mode determines how intermediate values between two endpoints are calculated.
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    
                // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    
                // This one is important
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            }
    
            public static Size MeasureDrawTextBitmapSize(string text, Font font)
            {
                Bitmap bmp = new Bitmap(1, 1);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    SizeF size = g.MeasureString(text, font);
                    return new Size((int)(Math.Ceiling(size.Width)), (int)(Math.Ceiling(size.Height)));
                }
    
            }
    
            public static int GetMaximumFontSizeFitInRectangle(string text, Font font, RectangleF rectanglef, bool isWarp, int MinumumFontSize=6, int MaximumFontSize=1000)
            {
                Font newFont;
                Rectangle rect = Rectangle.Ceiling(rectanglef);
    
                for (int newFontSize = MinumumFontSize; ; newFontSize++)
                {
                    newFont = new Font(font.FontFamily, newFontSize, font.Style);
    
                    List<string> ls = WarpText(text, newFont, rect.Width);
    
                    StringBuilder sb = new StringBuilder();
                    if (isWarp)
                    {
                        for (int i = 0; i < ls.Count; ++i)
                        {
                            sb.Append(ls[i] + Environment.NewLine);
                        }
                    }
                    else
                    {
                        sb.Append(text);
                    }
    
                    Size size = MeasureDrawTextBitmapSize(sb.ToString(), newFont);
                    if (size.Width > rectanglef.Width || size.Height > rectanglef.Height)
                    {
                        return (newFontSize - 1);
                    }
                    if (newFontSize >= MaximumFontSize)
                    {
                        return (newFontSize - 1);
                    }
    
                }
    
            }
    
            public static List<string> WarpText(string text, Font font, int lineWidthInPixels)
            {
                string[] originalLines = text.Split(new string[] { " " }, StringSplitOptions.None);
    
                List<string> wrappedLines = new List<string>();
    
                StringBuilder actualLine = new StringBuilder();
                double actualWidthInPixels = 0;
    
                foreach (string str in originalLines)
                {
                    Size size = MeasureDrawTextBitmapSize(str, font);
    
                    actualLine.Append(str + " ");
                    actualWidthInPixels += size.Width;
    
                    if (actualWidthInPixels > lineWidthInPixels)
                    {
                        actualLine =  actualLine.Remove(actualLine.ToString().Length - str.Length - 1, str.Length);
                        wrappedLines.Add(actualLine.ToString());
                        actualLine.Clear();
                        actualLine.Append(str + " ");
                        actualWidthInPixels = size.Width;
                    }
                }
    
                if (actualLine.Length > 0)
                {
                    wrappedLines.Add(actualLine.ToString());
                }
    
                return wrappedLines;
            }
    
            public static Bitmap DrawTextToBitmap(string text, Font font, Color color, DrawMethod mode, RectangleF rectanglef)
            {
                StringFormat drawFormat = new StringFormat();
                Bitmap bmp;
                switch (mode)
                {
                    case DrawMethod.AutosizeAccordingToText:
                        {
                            Size size = MeasureDrawTextBitmapSize(text, font);
    
                            if (size.Width == 0 || size.Height == 0)
                            {
                                bmp = new Bitmap(1, 1);
                            }
                            else
                            {
                                bmp = new Bitmap(size.Width, size.Height);
                            }
    
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                SetGraphicsHighQualityForTextRendering(g);
    
                                g.DrawString(text, font, new SolidBrush(color), 0, 0);
    
                                return bmp;
                            }
    
                        }
                    case DrawMethod.AutoWarpInConstantRectangle:
                        {
                            Rectangle rect =  Rectangle.Ceiling(rectanglef);
                            bmp = new Bitmap(rect.Width,rect.Height);
    
                            if (rect.Width == 0 || rect.Height == 0)
                            {
                                bmp = new Bitmap(1, 1);
                            }
                            else
                            {
                                bmp = new Bitmap(rect.Width, rect.Height);
                            }
    
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                SetGraphicsHighQualityForTextRendering(g);
    
                                g.DrawString(text, font, new SolidBrush(color), rectanglef, drawFormat);
    
                                return bmp;
                            }
    
                        }
                    case DrawMethod.AutoFitInConstantRectangleWithoutWarp:
                        {
                            Rectangle rect = Rectangle.Ceiling(rectanglef);
    
                            bmp = new Bitmap(rect.Width, rect.Height);
    
                            if (rect.Width == 0 || rect.Height == 0)
                            {
                                bmp = new Bitmap(1, 1);
                            }
                            else
                            {
                                bmp = new Bitmap(rect.Width, rect.Height);
                            }
    
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                int fontSize = GetMaximumFontSizeFitInRectangle(text, font, rectanglef, false);
    
                                SetGraphicsHighQualityForTextRendering(g);
    
                                g.DrawString(text, new Font(font.FontFamily, fontSize,font.Style, GraphicsUnit.Point), new SolidBrush(color), rectanglef, drawFormat);
    
    
                                return bmp;
                            }
    
                        }
                    case DrawMethod.AutoFitInConstantRectangleWithWarp:
                        {
                            Rectangle rect = Rectangle.Ceiling(rectanglef);
    
                            if (rect.Width == 0 || rect.Height == 0)
                            {
                                bmp = new Bitmap(1, 1);
                            }
                            else
                            {
                                bmp = new Bitmap(rect.Width, rect.Height);
                            }
    
                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                int fontSize = GetMaximumFontSizeFitInRectangle(text, font, rectanglef, true);
    
                                SetGraphicsHighQualityForTextRendering(g);
    
                                g.DrawString(text, new Font(font.FontFamily, fontSize, font.Style, GraphicsUnit.Point), new SolidBrush(color), rectanglef, drawFormat);
    
    
                                return bmp;
                            }
    
                        }
                }
                return null;
               
            }
    
          
    
        }
    }
    
