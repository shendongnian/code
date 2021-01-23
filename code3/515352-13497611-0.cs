    void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var urlCurrent = e.Url.ToString();
                var browser = (WebBrowser)sender;
    
                if (!(urlCurrent.StartsWith("http://") || urlCurrent.StartsWith("https://")))
                {
                    // in AJAX     
                }
                if (e.Url.AbsolutePath != browser.Url.AbsolutePath)
                {
                    // IFRAME           
                }
                else
                {
                    //  DOCUMENT IS LOADED 100%
                    Debug.WriteLine("DocumentCompleted " + DateTime.Now.TimeOfDay.ToString());
    
                    _pageReady = true; // Here it goes!!!! :)
    
                    try
                    {
                        mshtml.IHTMLDocument2 docs2 = (mshtml.IHTMLDocument2)web.Document.DomDocument;
                        mshtml.IHTMLDocument3 docs3 = (mshtml.IHTMLDocument3)web.Document.DomDocument;
                        mshtml.IHTMLElement2 body2 = (mshtml.IHTMLElement2)docs2.body;
                        mshtml.IHTMLElement2 root2 = (mshtml.IHTMLElement2)docs3.documentElement;
    
                        // Determine dimensions for the image; we could add minWidth here
                        // to ensure that we get closer to the minimal width (the width
                        // computed might be a few pixels less than what we want).
                        int width = Math.Max(body2.scrollWidth, root2.scrollWidth);
                        int height = Math.Max(root2.scrollHeight, body2.scrollHeight);
    
                        //get the size of the document's body
                        Rectangle docRectangle = new Rectangle(0, 0, width, height);
    
                        web.Width = docRectangle.Width;
                        web.Height = docRectangle.Height;
    
                        //if the imgsize is null, the size of the image will 
                        //be the same as the size of webbrowser object
                        //otherwise  set the image size to imgsize
                        Rectangle imgRectangle;
                        if (imgsize == null) imgRectangle = docRectangle;
                        else imgRectangle = new System.Drawing.Rectangle() { Location = new System.Drawing.Point(0, 0), Size = imgsize.Value };
    
                        //create a bitmap object 
                        __Bitmap = new Bitmap(imgRectangle.Width, imgRectangle.Height);
    
                        //Rectangle resolution = Screen.PrimaryScreen.Bounds;
                        //__Bitmap.SetResolution(resolution.Width, resolution.Height); 
    
                        //get the viewobject of the WebBrowser
                        IViewObject ivo = web.Document.DomDocument as IViewObject;
    
                        using (Graphics g = Graphics.FromImage(__Bitmap))
                        {
                            //get the handle to the device context and draw
                            IntPtr hdc = g.GetHdc();
                            ivo.Draw(1, -1, IntPtr.Zero, IntPtr.Zero,
                                     IntPtr.Zero, hdc, ref imgRectangle,
                                     ref docRectangle, IntPtr.Zero, 0);
                            g.ReleaseHdc(hdc);
                        }
    
                        //var randomPart = System.IO.Path.GetRandomFileName();
                        //__Bitmap.Save(@"D:\t" + randomPart + ".png");
    
                        if (CropRectangle != null)
                        {
                            if (CropRectangle.Width > 0 && CropRectangle.Height > 0)
                            {
                                Bitmap bmpCrop = __Bitmap.Clone(CropRectangle, __Bitmap.PixelFormat);
                                __Bitmap = bmpCrop;
                            }
                        }
    
                        //__Bitmap.Save(@"D:\cropped" + randomPart + ".png");
    
                        bitmapPointer = __Bitmap.GetHbitmap();
                    }
                    catch
                    {
                        //System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                }
            }
