    string homedir = Path.GetDirectoryName(Application.ExecutablePath);
    string xml = Path.Combine( homedir, "settings.xml" );
    
    FileStream stream = new FileStream( xml, FileMode.Open );
    
    XmlReaderSettings readerSettings = new XmlReaderSettings();
    readerSettings.IgnoreWhitespace = false;
    XmlReader reader = XmlTextReader.Create( stream, readerSettings );
    
    while( reader.Read() ){
    
        if ( reader.MoveToContent() == XmlNodeType.Element && reader.Name != "data" ){
            string name = reader.Name;
            string value = null;
            if (!reader.IsEmptyElement) 
            {
              reader.Read(); // advances reader to element content
              value = reader.ReadContentAsString(); // advances reader to endelement
            }
            reader.Read(); // advance reader to element content
            System.Diagnostics.Trace.WriteLine(
                reader.NodeType 
                + " "
                + name
                + " " 
                + value
            );
        }
    }
    
    stream.Close(); 
