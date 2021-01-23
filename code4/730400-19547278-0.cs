    public class WebConsoleWriter : TextWriter
    {
        HttpResponseBase Response { get; set; }
        bool FlushAfterEveryWrite { get; set; }
        bool AutoScrollToBottom { get; set; }
        Color BackgroundColor { get; set; }
        Color TextColor { get; set; }
        public WebConsoleWriter(HttpResponseBase response, bool flushAfterEveryWrite, bool autoScrollToBottom)
        {
            Response = response;
            FlushAfterEveryWrite = flushAfterEveryWrite;
            AutoScrollToBottom = autoScrollToBottom;
            BackgroundColor = Color.White;
            TextColor = Color.Black;
        }
        public WebConsoleWriter(HttpResponseBase response, bool flushAfterEveryWrite,  bool autoScrollToBottom, Color backgroundColor, Color textColor)
        {
            Response = response;
            FlushAfterEveryWrite = flushAfterEveryWrite;
            AutoScrollToBottom = autoScrollToBottom;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }
        public virtual void WritePageBeforeStreamingText()
        {
            string headerFormat =
    @"<!DOCTYPE html>
    <html>
    <head>
        <title>Web Console</title>
        <style>
            html {{
                background-color: {0};
                color: {1};
            }}
        </style>        
    </head>
    <body><pre>";
            string backgroundColorHex = ColorTranslator.ToHtml(BackgroundColor);
            string foregroundColorHex = ColorTranslator.ToHtml(TextColor);
            Response.Write(string.Format(headerFormat, backgroundColorHex, foregroundColorHex));
            // Add a 256 byte comment because I read that some browsers will automatically buffer the first 256 bytes.
            Response.Write("<!--");
            Response.Write(new string('*', 256));
            Response.Write("-->");
            Response.Flush();
        }
        public virtual void WritePageAfterStreamingText()
        {
            Response.Write("</pre></body></html>");
        }
        public override void Write(string value)
        {
            string encoded = Encode(value);
            Response.Write(encoded);            
            if (FlushAfterEveryWrite)
                Response.Flush();
        }
        public override void WriteLine(string value)
        {
            Response.Write(Encode(value) + "\n");
            if (AutoScrollToBottom)
                ScrollToBottom();
            if (FlushAfterEveryWrite)
                Response.Flush();
        }
        public override void WriteLine()
        {
            Response.Write('\n');
            if (AutoScrollToBottom)
                ScrollToBottom();
            if (FlushAfterEveryWrite)
                Response.Flush();
        }
        private string Encode(string s)
        {
            return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
        public override void Flush()
        {
            Response.Flush();
        }
        public void ScrollToBottom()
        {
            Response.Write("<script>window.scrollTo(0, document.body.scrollHeight);</script>");
        }
        public override System.Text.Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }
    }
