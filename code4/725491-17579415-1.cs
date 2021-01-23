     using (var doc = new Doc())
                {
                    if(!EnableCache)
                        doc.HtmlOptions.PageCacheClear();
    
                    if (MakeLandscape)
                    {
                        var w = doc.MediaBox.Width;
                        var h = doc.MediaBox.Height;
                        var l = doc.MediaBox.Left;
                        var b = doc.MediaBox.Bottom;
    
                        doc.Transform.Rotate(90, l, b);
                        doc.Transform.Translate(w, 0);
    
                        doc.Rect.Width = h;
                        doc.Rect.Height = w;
                    }
                    
                    doc.HtmlOptions.Timeout = 60000;
                    doc.HtmlOptions.PageCacheEnabled = EnableCache;
                    doc.HtmlOptions.PageCacheExpiry = 600000;
    
                    doc.HtmlOptions.Engine = Engine;
                    doc.Rect.Inset(PageInsetHorizontal, PageInsetVertical);
                    doc.Color.String = "255, 255, 255";
    
                    doc.HtmlOptions.Paged = false;
                    doc.HtmlOptions.BrowserWidth = (MakeLandscape ? PageWidth + PageInsetHorizontal : PageHeight + PageInsetVertical) * Convert.ToInt32(doc.Rect.Width / doc.Rect.Height);
    
                    var id = doc.AddImageUrl(Url);
    
                                   if (MakeLandscape)
                {
                    var scrollWidth = doc.GetInfoInt(id, "ScrollWidth");
                    var contentWidth = doc.GetInfoInt(id, "ContentWidth");
                    if (scrollWidth > contentWidth)
                    {
                        var scrollHeight = doc.GetInfoInt(id, "ScrollHeight");
                        doc.Delete(id);
                        doc.HtmlOptions.BrowserWidth = Convert.ToInt32(scrollHeight * doc.Rect.Width / doc.Rect.Height);
                        
                        id = doc.AddImageUrl(Url);
                    }
                }
                else
                {
                    var scrollHeight = doc.GetInfoInt(id, "ScrollHeight");
                    var contentHeight = doc.GetInfoInt(id, "ContentHeight");
                    if (scrollHeight > contentHeight + (PageInsetVertical *2))
                    {
                        var scrollWidth = doc.GetInfoInt(id, "ScrollWidth");
                        doc.Delete(id);
                        doc.HtmlOptions.BrowserWidth = Convert.ToInt32(((double)scrollHeight / contentHeight) * scrollWidth);
                        id = doc.AddImageUrl(Url);
                    }
                }
    
                    if (MakeLandscape)
                    {
                        doc.SetInfo(doc.GetInfoInt(doc.Root, "Pages"), "/Rotate", "90");
                    }
                    
                    using (var ms = new MemoryStream())
                    {
                        doc.Save(ms);
                        if (ms.CanSeek)
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                        }
                        return ms.GetBuffer();
                    }
                }
