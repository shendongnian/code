    public Bitmap GetImage(string id)
        {
            HtmlElement e = webBrowser1.Document.GetElementById(id);
            IHTMLImgElement img = (IHTMLImgElement)e.DomElement;
            IHTMLElementRenderFixed render = (IHTMLElementRenderFixed)img;
    
            Bitmap bmp = new Bitmap(e.OffsetRectangle.Width, e.OffsetRectangle.Height);
            Graphics g = Graphics.FromImage(bmp);
            IntPtr hdc = g.GetHdc();
            render.DrawToDC(hdc);
            g.ReleaseHdc(hdc);
    
            return bmp;
        }
