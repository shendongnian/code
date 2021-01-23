    public static class Extensions
    {
       public static int? ToInt32(this XElement element)
       {
          if (element == null) return null;
          if (element.IsEmpty) return null;
          
          // If the element is declared as <Value></Value>,
          // IsEmpty will be false, but the value will be an empty string:
          if (string.IsNullOrEmpty(element.Value)) return null;
          
          return XmlConvert.ToInt32(element.Value);
       }
    }
    
    myRecord.myField = doc.Descendants("Information")
       .Where(x => (string)x.Element("Name") == "myField")
       .Select(x => x.Element("Value").ToInt32()).FirstOrDefault();
