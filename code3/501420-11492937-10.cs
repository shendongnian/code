    #region Using Statements
    using System;
    using System.Xml.Linq;
    #endregion 
    class Program {
        static void Main( string[ ] args ) {
            XDocument doc = new XDocument( new XElement( "body", 
                                               new XElement( "level1", 
                                                   new XElement( "level2", "text" ), 
                                                   new XElement( "level2", "other text" ) ) ) );
            doc.Save( "D:\\document.xml" );
        }
    }
