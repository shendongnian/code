    public static string drawTextOnMarker(string markerfile, string text, string newfilename,Color textColor)
        {
            //Uri uri = new Uri(markerfile, UriKind.Relative);
            //markerfile = uri.AbsolutePath;
            //uri = new Uri(newfilename, UriKind.Relative);
            //newfilename = uri.AbsolutePath;
            if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(newfilename)))
            {
                try
                {
                    Bitmap bmp = new Bitmap(System.Web.HttpContext.Current.Server.MapPath(markerfile));
                    Graphics g = Graphics.FromImage(bmp);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    StringFormat strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Center;
                    SolidBrush myBrush = new SolidBrush(textColor);
                    float fontsize = 10;
                    bool sizeSetupCompleted = false;
                    while (!sizeSetupCompleted)
                    {                        
                        SizeF mySize = g.MeasureString(text, new Font("Verdana", fontsize, FontStyle.Bold));
                        if (mySize.Width > 24 || mySize.Height > 13)
                        {
                            fontsize-= float.Parse("0.1");
                        }
                        else
                        {
                            sizeSetupCompleted = true;
                        }
                    }
                    g.DrawString(text, new Font("Verdana", fontsize, FontStyle.Bold), myBrush, new RectangleF(4, 3, 24, 8), strFormat);
                    bmp.Save(System.Web.HttpContext.Current.Server.MapPath(newfilename));
                    return newfilename.Substring(2);
                }
                catch (Exception)
                {
                    return markerfile.Substring(2);
                }
            }
            return newfilename.Substring(2);
        }
