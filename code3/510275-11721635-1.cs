            public static void AddWithContext(this XElement element, string fragment)
            {
                XmlNameTable nt = new NameTable();
                XmlNamespaceManager mgr = new XmlNamespaceManager(nt);
    
                IDictionary<string, string> inScopeNamespaces = element.CreateNavigator().GetNamespacesInScope(XmlNamespaceScope.ExcludeXml);
    
                foreach (string prefix in inScopeNamespaces.Keys)
                {
                    mgr.AddNamespace(prefix, inScopeNamespaces[prefix]);
                }
    
                using (XmlWriter xw = element.CreateWriter())
                {
                    using (StringReader sr = new StringReader(fragment))
                    {
                        using (XmlReader xr = XmlReader.Create(sr, new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Fragment }, new XmlParserContext(nt, mgr, xw.XmlLang, xw.XmlSpace)))
                        {
                            xw.WriteNode(xr, false);
                        }
                    }
                    xw.Close();
                }
            }
        }
    
        class Program
        {
            static void Main()
            {
                XElement foo = XElement.Parse(@"<foo xmlns=""http://example.com/ns1"" xmlns:html=""http://example.com/html"">
      <bar>bar 1</bar>
    </foo>");
                foo.Add(new XElement(foo.GetNamespaceOfPrefix("html") + "p", "Test"));
    
                Console.WriteLine(foo);
                Console.WriteLine();
    
                foo.AddWithContext("<html:p>Test 2.</html:p><bar>bar 2</bar><html:b>Test 3.</html:b>");
    
                foo.Save(Console.Out, SaveOptions.OmitDuplicateNamespaces);
    
            }
