    using System;
    using System.IO;
    using System.Xml;
    
    public class Sample
    {
      public static void Main()
      {
        string inputpath = "C:\....";
        //Create the XmlDocument.
        XmlDocument doc = new XmlDocument();
            
        //Create a new node and add it to the document.
        //The text node is the content of the price element.
        XmlElement elem = doc.CreateElement("Inputpath");
        XmlText text = doc.CreateTextNode(inputpath);
        doc.DocumentElement.AppendChild(elem);
        doc.DocumentElement.LastChild.AppendChild(text);
    
        doc.Save(Console.Out);
    
      }
    }
