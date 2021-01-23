    Selection oSelection = m_oApp.GetSelection();
    Sections ss = oSelection.GetSections();
    Section s = ss.GetFirst();
    HeadersFooters hf = s.GetHeaders();
    HeaderFooter hfItem = hf.Item(1);
    PageNumbers ps = hfItem.GetPageNumbers();
    //to get the First pageNumber
    long nNo = ps.GetStartingNumber();
    HeadersFooters footers = s.GetFooters();
    HeaderFooter footer = footers.Item(1);
    Range r = footer.GetRange();
    //to get the First page footer text
    CString strFooterText = r.GetText();
