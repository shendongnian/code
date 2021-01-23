        IHTMLTxtRange rng = null;
        private bool FindString(HtmlElement elem, string str)
        {           
            bool strFound = false;
            try
            {
                if (rng != null)
                {
                    rng.collapse(false);
                    strFound = rng.findText(str, 1000000000, 0);
                    if (strFound)
                    {
                        rng.select();
                        rng.scrollIntoView(true);
                    }
                }
                if (rng == null)
                {
                    IHTMLDocument2 doc =
                           elem.Document.DomDocument as IHTMLDocument2;
                    IHTMLBodyElement body = doc.body as IHTMLBodyElement;
                    rng = body.createTextRange();
                    rng.moveToElementText(elem.DomElement as IHTMLElement);
                    strFound = rng.findText(str, 1000000000, 0);
                    if (strFound)
                    {
                        rng.select();
                        rng.scrollIntoView(true);
                    }
                }
            }
            catch 
            {
              
            }
            return strFound;
        }
