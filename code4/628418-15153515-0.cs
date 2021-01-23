    /// <summary>
            /// Returns a thumbnail for the current member values
            /// </summary>
            /// <returns>Thumbnail bitmap</returns>
            protected Bitmap GetThumbnail()
            {
                try
                {
                // WebBrowser is an ActiveX control that must be run in a single-threaded
                // apartment so create a thread to create the control and generate the
                // thumbnail
                Thread thread = new Thread(new ThreadStart(GetThumbnailWorker));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
                return _bmp;
                }
                catch (Exception ex)
                {
                    using (StreamWriter writer = new StreamWriter("log.txt", true))
                    {
                        writer.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), ex.ToString()));
                        writer.Flush();
                        writer.Close();
                    }
                    return null;
                }
            }
    
    
    /// <summary>
            /// Creates a WebBrowser control to generate the thumbnail image
            /// Must be called from a single-threaded apartment
            /// </summary>
            protected void GetThumbnailWorker()
            {
                try
                {
                    using (WebBrowser browser = new WebBrowser())
                    {
                        browser.ClientSize = new Size(_width, _height);
                        //browser.ScrollBarsEnabled = false;
                        browser.ScriptErrorsSuppressed = true;
                        browser.Navigate(_url);
                        // Wait for control to load page
                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                            Application.DoEvents();
                        // Render browser content to bitmap
                        _bmp = new Bitmap(_thumbWidth, _thumbHeight);
                        browser.DrawToBitmap(_bmp, new Rectangle(0, 0, _thumbWidth, _thumbHeight));
                    }
                }
                catch (Exception ex)
                {
                    using (StreamWriter writer = new StreamWriter("log.txt", true))
                    {
                        writer.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), ex.ToString()));
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
