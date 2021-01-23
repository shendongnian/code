            public string URL { set; get; }
            public string Element { set; get; }
            public bool FindByID { set; get; }
            private WebBrowser b { set; get; }
            private mshtml.IHTMLDocument2 doc { set; get; }
            public delegate void DownloadCompletedDelegate(string result);
            private DownloadCompletedDelegate _downloadedComplete;
            public void GetPageElementInnerHTML(string url, string element, bool findById, DownloadCompletedDelegate downloadComplete)
            {
                _downloadedComplete = downloadComplete;
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
                _downloadedComplete.Invoke(result);
            }
        }
