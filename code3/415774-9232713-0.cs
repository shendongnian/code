    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using mshtml;
    using System.Collections;
    
    namespace MyCompany.WebpageGrabber
    {
        // A delegate type for hooking up change notifications.
        public delegate void ChangedEventHandler(object sender, EventArgs e);
     
        public class WebGrabber : ArrayList
        {
            // An event that clients can use to be notified whenever the
            // elements of the list change.
            public event ChangedEventHandler Changed;
    
            // Invoke the Changed event; called whenever list changes
            protected virtual void OnChanged(EventArgs e)
            {
                if (Changed != null)
                    Changed(this, e);
            }
    
            // Override some of the methods that can change the list;
            // invoke event after each
            public override int Add(object value)
            {
                int i = base.Add(value);
                OnChanged(EventArgs.Empty);
                return i;
            }
    
            public override void Clear()
            {
                base.Clear();
                OnChanged(EventArgs.Empty);
            }
    
            public override object this[int index]
            {
                set
                {
                    base[index] = value;
                    OnChanged(EventArgs.Empty);
                }
            }
    
            public string URL { set; get; }
    
            public string Element { set; get; }
    
            public bool FindByID { set; get; }
    
            private WebBrowser b { set; get; }
    
            private mshtml.IHTMLDocument2 doc { set; get; }
    
            public void GetPageElementInnerHTML(string url, string element, bool findById)
            {
                URL = url;
                Element = element;
                FindByID = findById;
    
                b = new WebBrowser();
                b.Navigate(url);
                b.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(b_DocumentCompleted);
            }
    
            void b_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                doc = (IHTMLDocument2)b.Document.DomDocument;
    
                string result = "<html>";
    
                IHTMLElement head = (IHTMLElement)((IHTMLElementCollection)doc.all.tags("head")).item(null, 0);
    
                result += "<head>" + head.innerHTML + "</head>";
    
                if (null != doc)
                {
                    foreach (IHTMLElement element in doc.all)
                    {
                        if (element is mshtml.IHTMLDivElement)
                        {
                            dynamic div = element as HTMLDivElement;
    
                            if (FindByID)
                            {
                                string id = div.id;
    
                                if (id == Element)
                                {
                                    result += "<body>" + div.IHTMLElement_innerHTML + "</body></html>";
    
                                    break;
                                }
                            }
                            else
                            {
                                string className = div.className;
    
                                if (className == Element)
                                {
                                    result += "<body>" + div.IHTMLElement_innerHTML + "</body></html>";
    
                                    break;
                                }
                            }
                        }
                    }
                }
                doc.close();
    
                this.Add(result);
            }
        }
    }
