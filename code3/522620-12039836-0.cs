            private void webBrowser1_DocumentCompleted(
                              object sender, 
                              WebBrowserDocumentCompletedEventArgs e)
            {
                // obtain HtmlDocument
                HtmlDocument htmlDoc = webBrowser1.Document;
    
                // loop over ALL elements in HtmlDoc
                foreach(HtmlElement element in htmlDoc.All)
                {
                    // for the HtmlElements type fetch its suported Events
                    // from the typeinfo
                    // we use a LinqQuery to filter in the future
                    var listOfEvents = from domInt in element.GetType().GetEvents()
                                       // where domInt.Name.Contains("click")
                                       select domInt;
                    // iterated over the EventMembers
                    foreach (var htmlevent in listOfEvents) 
                    {
                        // invoke .Net managed AddEventHandler 
                        htmlevent.AddEventHandler(
                            element, 
                            new HtmlElementEventHandler(GenericDomEvent));
                    }
                }
            }
    
            // do usefull stuff with the even raised
            private void GenericDomEvent(object sender, HtmlElementEventArgs e)
            {
                Debug.WriteLine(e.EventType);
            }
