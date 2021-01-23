        public static Foo ReadXML(string file)
        {
                Foo foo = null;
                XDocument xdoc = XDocument.Load(file);
                xdoc.Descendants().Where(e => string.IsNullOrEmpty(e.Value)).Remove();
                XmlSerializer xmlSer = new XmlSerializer(typeof(Foo));
                using (var reader = xdoc.Root.CreateReader())
                {
                    foo = (Foo)xmlSer.Deserialize(reader);
                    reader.Close();
                }
                if (foo == null)
                    foo = new Foo();
                return foo;
        }
