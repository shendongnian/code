    var src = docHeader.Attribute("InvoiceSource");
    var num = docHeader.Attribute("InvoiceNumber");
    
    if(src != null && num != null)
    {
      invoice.Add(
        new XAttribute("InvoiceNumber", num.value), 
        new XAttribute("InvoiceSource", src.value)); 
    }
