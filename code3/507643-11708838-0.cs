              public delegate void DOMEvent(IHTMLEventObj e);
      private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (this.webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                return;
            else
            {
                HTMLDocument htmlDoc = (HTMLDocument)this.webBrowser1.Document.DomDocument;
                DispHTMLDocument doc = (DispHTMLDocument)htmlDoc;
                DOMEventHandler onmousedownhandler = new DOMEventHandler(doc);
                onmousedownhandler.Handler += new DOMEvent(Mouse_Down);
                doc.onmousedown = onmousedownhandler;
                if (htmlDoc.frames.length > 0)
                {
                    FramesCollection FrameList = htmlDoc.frames;
                    for (int i = 0; i < FrameList.length; i++)
                    {
                        object id = (object)i;
                        IHTMLWindow2 frameWindow = (IHTMLWindow2)FrameList.item(ref id);
                        HTMLDocument frameDoc = (HTMLDocument)frameWindow.document;
                        DispHTMLDocument frameDispDoc = (DispHTMLDocument)frameDoc;
                        DOMEventHandler onmousedownhand = new DOMEventHandler(frameDispDoc);
                        onmousedownhand.Handler += new DOMEvent(Mouse_Down);
                        frameDispDoc.onmousedown = onmousedownhand;
                    }
                }
            }
        }
            public class DOMEventHandler
            {
            public DOMEvent Handler;
            DispHTMLDocument Document;
            public DOMEventHandler(DispHTMLDocument doc)
            {
                this.Document = doc;
            }
            [DispId(0)]
            public void Call()
            {
                Handler(Document.parentWindow.@event);
            }
        }
        
           public void Mouse_Down(IHTMLEventObj e)
            {
            IHTMLElement element = (mshtml.IHTMLElement)e.srcElement;
            label1.Text = element.id;
             }
