    private void test() {
            Stream xsltStream = GetEmbeddedResource("TestSaxon.Resources.test.xsl");
           
            Processor processor = new Processor();
            
            DocumentBuilder db = processor.NewDocumentBuilder();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xsltStream);
            XdmNode xdmNode = db.Build(xmlDocument);
            
            XsltTransformer transformer = processor.NewXsltCompiler().Compile(xdmNode).Load();
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var input = new FileInfo(path + @"\input.xml");
            var output = new FileInfo(path + @"\result.xml");
            var destination = new DomDestination();
            using (var inputStream = input.OpenRead())
            {
                transformer.SetInputStream(inputStream, new Uri(input.DirectoryName));
                transformer.Run(destination);
            }
            destination.XmlDocument.Save(output.FullName);
        }
        protected static Stream GetEmbeddedResource(string path)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream(path);
            return stream;
        }
