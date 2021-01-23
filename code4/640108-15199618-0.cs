    Document doc = this.application.ActiveDocument;
    Section wordSection = doc.Sections[1];    
    Range footer = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;                              
    footer.Fields.Add(footer, WdFieldType.wdFieldEmpty, @"PAGE \* ARABIC", true);                               
    footer.Collapse(WdCollapseDirection.wdCollapseStart);
    footer.InsertBefore("\t \t");
    footer.InsertBefore(doc.FullName);                                                          
    footer.Font.Name = "Arial";
