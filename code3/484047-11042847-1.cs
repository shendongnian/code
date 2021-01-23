        static TextWriter GetWriter(bool wantSave)
        {
            if (wantSave)
            {
                var fs = new FileStream(StorageFile, FileMode.Create);
                return new StreamWriter(fs, new UTF8Encoding());
            }
            return Console.Out;
        }
        private static void ShoworSave(MyRequest r, bool wantSave)
        {
            if (r==null)
            {
                Console.WriteLine(" --null--");
                return;
            }
            Console.WriteLine("\n");
            var writerSettings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true
            };
            using (XmlWriter xmlWriter =
                   XmlWriter.Create(GetWriter(wantSave), writerSettings))
            {
                XmlSerializer ser = new XmlSerializer(r.GetType());
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "http://mynamespace");
                ser.Serialize(xmlWriter, r, ns);
            }
            Console.WriteLine("\n");
        }
