    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    namespace XmlSandbox {
        class Program {
            static void Main( string[] args ) {
                string l_xmlLiteral =
                    "<html>\n" +
                    "   <head>\n" +
                    "       <title>Test Table Page</title>\n" +
                    "   </head>\n" +
                    "   <body>\n" +
                    "       <table border=\"1\" cellpadding=\"3\" cellspacing=\"5\">\n" +
                    "           <tr>\n" +
                    "               <td>Test Row One</td>\n" +
                    "               <td>Test Content</td>\n" +
                    "           </tr>\n" +
                    "           <tr>\n" +
                    "               <td>Test Row Two</td>\n" +
                    "               <td>Test Content</td>\n" +
                    "           </tr>\n" +
                    "           <tr>\n" +
                    "               <td>Test Row Three</td>\n" +
                    "               <td>Test Content</td>\n" +
                    "           </tr>\n" +
                    "       </table>\n" +
                    "   </body>\n" +
                    "</html>";
                var l_document = XDocument.Parse( l_xmlLiteral );
                var l_navigator = l_document.CreateNavigator();
                var l_contentCell = l_navigator.SelectSingleNode( "//td[preceding-sibling::td/text()='Test Row Two']" );
                Console.WriteLine( l_contentCell.Value );
            }
        }
    }
