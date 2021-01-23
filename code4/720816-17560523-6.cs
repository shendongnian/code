    using mshtml;
    using System.Drawing;
    using System.Runtime.InteropServices;
    [ComImport, InterfaceType((short)1), Guid("3050F669-98B5-11CF-BB82-00AA00BDCE0B")]
    private interface IHTMLElementRenderFixed
    {
        void DrawToDC(IntPtr hdc);
        void SetDocumentPrinter(string bstrPrinterName, IntPtr hdc);
    }
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
