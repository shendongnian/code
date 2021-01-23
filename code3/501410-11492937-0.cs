    class Program {
        static void Main( string[ ] args ) {
            XmlDocument doc = new XmlDocument();
            XmlElement element1 = doc.CreateElement( "", "body", "" );
            doc.AppendChild( element1 );
            XmlElement element2 = doc.CreateElement( "", "level1", "" );
            element1.AppendChild( element2 );
            XmlElement element3 = doc.CreateElement( "", "level2", "" );
            XmlText text1 = doc.CreateTextNode( "text" );
            element3.AppendChild( text1 );
            element2.AppendChild( element3 );
            XmlElement element4 = doc.CreateElement( "", "level2", "" );
            XmlText text2 = doc.CreateTextNode( "another text" );
            element4.AppendChild( text2 );
            element2.AppendChild( element4 );
            doc.Save( "D:\\my_xml_file.xml" );
        }
    }
