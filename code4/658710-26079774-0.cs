                WebSession session = WebCore.CreateWebSession(folder + "\\b" + i, prefs);
                                WebView view = WebCore.CreateWebView(1920, 1080, session, WebViewType.Offscreen);
                                view.LoadingFrameComplete += (se, ev) =>
                                {
                                    if (ev.IsMainFrame)
                                    {
                                        var bitmapSurface = (BitmapSurface)((WebView)se).Surface;
                                        var writeableBitmap = new WriteableBitmap(((WebView)se).Width, ((WebView)se).Height, 96, 96, PixelFormats.Bgra32, null);
                                        writeableBitmap.Lock();
                                        bitmapSurface.CopyTo(writeableBitmap.BackBuffer, bitmapSurface.RowSpan, 4, false, false);
                                        writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, ((WebView)se).Width, ((WebView)se).Height));
                                        writeableBitmap.Unlock();
                                        var image = new Image();
                                        image.Source = writeableBitmap;
                                        screenShot.Source = writeableBitmap;
                                    }
                                };
                            view.Source = "http://www.google.com".ToUri();
