	using System;
	using System.Xml;
	public class Sample {
	  public static void Main() {
		// Create the XmlDocument.
		XmlDocument doc = new XmlDocument();
		doc.Load(@"drive:/path/to/you/file.xml");
	   // Add a price element.
	   XmlElement newElem = doc.CreateElement("price");
	   newElem.InnerText = "10.95";
	   doc.DocumentElement.AppendChild(newElem);
		// Save the document to a file and auto-indent the output.
		XmlTextWriter writer = new XmlTextWriter("data.xml",null);
		writer.Formatting = Formatting.Indented;
		doc.Save(writer);
	  }
	}
