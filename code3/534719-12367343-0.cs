    var cb = pdfStamper.GetOverContent(1);
    var ct = new ColumnText(cb);
    ct.Alignment = Element.ALIGN_CENTER; 
    ct.SetSimpleColumn(36, 36, PageSize.A4.Width-36, PageSize.A4.Height-300); 
    ct.AddElement(table);
    ct.Go();
