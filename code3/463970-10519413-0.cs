    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Xsl;
    using System.Xml;
    
    namespace test.Transform
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                // Arguments
                // Stylesheet
                // XML-out
                // outpath-xml-path
    
                if (args.Length != 3)
                {
                    Console.WriteLine("parameters Stylesheet XML-out outpath-xml-path");
                    return;
                }
    
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(args[0]);
    
                var xml = new XmlDocument();
                xml.Load(args[1]);
    
                var xmlDocOut = new XmlDocument();
    
                using (XmlWriter xmlWriter = xmlDocOut.CreateNavigator().AppendChild())
                {
                    xslt.Transform(xml, null, xmlWriter);
                }
    
                xmlDocOut.Save(args[2]);
            }
        }
    }
