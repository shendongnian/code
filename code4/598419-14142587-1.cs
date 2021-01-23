    private const string CRLF = "\r\n";
    private const string CRLFTAB = "\r\n\t";
    private const string CRLFTABTAB = "\r\n\t\t";
    private const string CRLFTABTABTAB = "\r\n\t\t";
    private object writeLock = new object();
    private void WriteToXml(string filename) {
      lock (writeLock) {
        using (FileStream stream = File.Open(filename, FileMode.Append, FileAccess.Write, FileShare.Read)) {
          using (XmlTextWriter xw = new XmlTextWriter(stream, Encoding.UTF8)) {
            xw.WriteStartElement("Product"); // writes the root
            {
              xw.WriteWhitespace(CRLFTAB);
              xw.WriteElementString("Ref", "1");
              xw.WriteWhitespace(CRLFTAB);
              xw.WriteElementString("Name", "Product 1");
              xw.WriteWhitespace(CRLFTAB);
              xw.WriteElementString("ShortName", "P1");
              xw.WriteWhitespace(CRLFTAB);
              xw.WriteElementString("Abbreviation", "P.1");
              xw.WriteWhitespace(CRLFTAB);
              xw.WriteElementString("Id", "494a8011-16a0-46ff-980f");
              xw.WriteWhitespace(CRLFTAB);
              xw.WriteStartElement("Attribs");
              {
                xw.WriteWhitespace(CRLFTABTAB);
                xw.WriteStartElement("ConfigAttribute");
                {
                  xw.WriteWhitespace(CRLFTABTABTAB);
                  xw.WriteElementString("Name", "price");
                  xw.WriteWhitespace(CRLFTABTABTAB);
                  xw.WriteElementString("Required", "false");
                  xw.WriteWhitespace(CRLFTABTABTAB);
                  xw.WriteElementString("ReadOnly", "true");
                  xw.WriteWhitespace(CRLFTABTABTAB);
                  xw.WriteElementString("Value", "200");
                  xw.WriteWhitespace(CRLFTABTABTAB);
                }
                xw.WriteEndElement(); // Write the close tag for the ConfigAttribute element
                xw.WriteWhitespace(CRLFTABTAB);
                xw.WriteWhitespace(CRLFTABTAB);
                xw.WriteStartElement("ConfigAttribute");
                {
                  xw.WriteWhitespace(CRLFTABTABTAB);
                  xw.WriteElementString("Name", "Quantity");
                  xw.WriteWhitespace(CRLFTABTABTAB);
                  xw.WriteElementString("Required", "true");
                  xw.WriteWhitespace(CRLFTABTABTAB);
                  xw.WriteElementString("ReadOnly", "true");
                  xw.WriteWhitespace(CRLFTABTABTAB);
                  xw.WriteElementString("Value", "1");
                  xw.WriteWhitespace(CRLFTABTABTAB);
                }
                xw.WriteEndElement(); // Write the close tag for the ConfigAttribute element
                xw.WriteWhitespace(CRLFTABTAB);
              }
              xw.WriteEndElement(); // Write the close tag for the Attribs element
              xw.WriteWhitespace(CRLF);
            }
            xw.WriteEndElement(); // Write the close tag for the root element
            xw.WriteWhitespace(CRLF);
            xw.Flush();
            xw.Close();
          }
          stream.Close();
        }
      }
    }
