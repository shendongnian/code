    #region Using Statements
    using System;
    using System.Xml;
    #endregion 
    class Program {
        static void Main( string[ ] args ) {
            XmlDocument doc = new XmlDocument( );
            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration( "1.0", "UTF-8", null );
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore( xmlDeclaration, root );
            //(2) string.Empty makes cleaner code
            XmlElement element1 = doc.CreateElement( string.Empty, "body", string.Empty );
            doc.AppendChild( element1 );
            XmlElement element2 = doc.CreateElement( string.Empty, "level1", string.Empty );
            element1.AppendChild( element2 );
            XmlElement element3 = doc.CreateElement( string.Empty, "level2", string.Empty );
            XmlText text1 = doc.CreateTextNode( "text" );
            element3.AppendChild( text1 );
            element2.AppendChild( element3 );
            XmlElement element4 = doc.CreateElement( string.Empty, "level2", string.Empty );
            XmlText text2 = doc.CreateTextNode( "other text" );
            element4.AppendChild( text2 );
            element2.AppendChild( element4 );
            doc.Save( "D:\\document.xml" );
        }
    }
