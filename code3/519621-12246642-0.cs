    void LoadingFinished(object sender, EventArgs args)
            {
                try
                {
                    myBrowser.Document.Body.SetAttribute("style", "overflow:hidden");
                    if (screenshotkey != "")
                    {
                        panel1.Height = myBrowser.Document.Body.ScrollHeight;
                        panel1.Width = myBrowser.Document.Body.ScrollWidth;
                        this.Size = new System.Drawing.Size(panel1.Width+20, panel1.Height+20);
    
                        if (!Directory.Exists("Screenshots"))
                        {
                            Directory.CreateDirectory("Screenshots");
                        }
    
                        Bitmap bitmap = new Bitmap(myBrowser.Width, myBrowser.Height);
                        for (int Xcount = 0; Xcount < bitmap.Width; Xcount++)
                        {
                            for (int Ycount = 0; Ycount < bitmap.Height; Ycount++)
                            {
    
                                bitmap.SetPixel(Xcount, Ycount, Color.Black);
                            }
                        }
                        myBrowser.DrawToBitmap(bitmap, new Rectangle(0, 0, myBrowser.Width, myBrowser.Height));
                        bitmap.Save("Screenshots/" + screenshotkey + ".png", ImageFormat.Png);
                    }
                }
                catch (Exception dfkvsn)
                {
                    errorloadingpage();
                }
            }
