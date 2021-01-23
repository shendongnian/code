    using System.Xml.Linq
    
    XElement books = XElement.Load("{file}");
    
    string _Attribute;
    foreach (var bookID in books.Elements("book")) 
    {
        if(bookID.Attribute("id") != null)
        {
            _Attribute = bookID.Attribute("book").Value;
            if(!Regex.IsMatch(_Attribute, @"-[0-9]+$"))
            {
                Regex.Replace(_Attribute, @"-[0-9]+$", "");
            }
            bookID.Attribute("id").Value = _Attribute;
        }
    }
