    var bkms = YourBookmarkStart;
    OpenXmlElement elem = bkms.NextSibling();
    RunProperties oldRunProperties = null;
    while (elem != null && !(elem is BookmarkEnd))
    {
        OpenXmlElement nextElem = elem.NextSibling();
        if (elem.HasChildren)
        {
    		try
            {
                 oldRunProperties = (RunProperties)elem.GetFirstChild<RunProperties>().Clone();
            }
            catch { }
        }
        if (!(elem is BookmarkStart))
            elem.Remove();
        elem = nextElem;
    }
    
    Run r = new Run(new Text(newText));
    if (oldRunProperties != null) r.PrependChild<RunProperties>(oldRunProperties);
    bkms.Parent.InsertAfter<Run>(r, bkms);
