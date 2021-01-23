    using System.Linq;
    using System.Xml.Linq;
    public void ProcessPhotos() {
        XDocument xDoc = XDocument.Load("<path to your xml file");
        foreach(XElement xProperty in xDoc.Descendants("Property")) {
            // goes through all Property xml elements
            foreach(XElement xPhoto in xProperty.Descendants("Photo")) {
                // and process all photos in current Property element
            }
        }
    }
