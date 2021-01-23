      XmlTextWriter kml = new XmlTextWriter(...)
      kml.Formatting = Formatting.Indented;
      kml.WriteStartElement("kml", "http://www.opengis.net/kml/2.2");
      kml.WriteStartElement("ScreenOverlay");
      kml.WriteElementString("name", "elephant");
      kml.WriteStartElement("Icon");
      kml.WriteElementString("href", "images/elephant.jpg");
      kml.WriteEndElement(); // Icon
      kml.WriteStartElement("overlayXY");    
      kml.WriteAttributeString("x", "0");
      kml.WriteAttributeString("y", "0");
      kml.WriteAttributeString("xunits", "fraction");
      kml.WriteAttributeString("yunits", "fraction");
      kml.WriteEndElement(); // overlayXY
      kml.WriteStartElement("screenXY");
      kml.WriteAttributeString("x", "0");
      kml.WriteAttributeString("y", "0");
      kml.WriteAttributeString("xunits", "pixels");
      kml.WriteAttributeString("yunits", "pixels");
      kml.WriteEndElement(); // screenXY
      ...
      kml.WriteEndElement(); // ScreenOverlay
      kml.WriteEndElement(); // kml
