    private class XDateElement : XElement
    {
       public XDateElement(XName name, DateTime Date) : 
         base(name, Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))
       { }
    }
