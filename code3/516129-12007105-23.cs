    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Xsl;
    
    class Program
    {
        static void Main(string[] args)
        {
            var databaseService = new SqlServerDatabaseService();
            
            // put CommonHistOrg.xslt into the 'ApplicationDocuments' database table:
            databaseService.StoreApplicationDocument(
                applicationName: "common",
                document:        XmlReader.Create("CommonHistOrg.xslt"));
            // load the XSLT stylesheet:
            var xslt = new XslCompiledTransform();
            xslt.Load(@"TestStylesheet.xslt", 
                settings: XsltSettings.Default, 
                stylesheetResolver: new XmlDbResolver(databaseService));
            // load the XML test input:
            var input = XmlReader.Create("TestInput.xml");
            // transform the test input and store the result in 'output':
            var output = new StringBuilder();
            xslt.Transform(input, XmlWriter.Create(output));
            // display the transformed output:
            Console.WriteLine(output.ToString());
            Console.ReadLine();
        }
    }
