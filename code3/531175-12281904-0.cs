    IXpsFixedDocumentSequenceReader fixedDocSeqReader = document.FixedDocumentSequenceReader;
            IXpsFixedDocumentReader _document = fixedDocSeqReader.FixedDocuments[0];
            IXpsFixedPageReader _page = _document.FixedPages[viewer.MasterPageNumber];
            System.Xml.XmlReader _pageContentReader = _page.XmlReader;
            if (_pageContentReader != null)
            {
                while (_pageContentReader.Read())
                {
                    if (_pageContentReader.Name == "Glyphs")
                    {
                        if (_pageContentReader.HasAttributes)
                        {
                            if (_pageContentReader.GetAttribute("UnicodeString") != null)
                            {
                               _resultingtext=_pageContentReader.GetAttribute("UnicodeString"));
                            }
                        }
                    }
                }
            }
