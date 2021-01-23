    /// <summary>
        /// Returns a System.IO.Packaging.Package stream for the given word open XML.
        /// </summary>
        /// <param name="wordOpenXML">The word open XML.</param>
        /// <returns></returns>
        public static MemoryStream GetPackageStreamFromWordOpenXML(string wordOpenXML)
        {
            XDocument doc = XDocument.Parse(wordOpenXML);
            XNamespace pkg =
               "http://schemas.microsoft.com/office/2006/xmlPackage";
            XNamespace rel =
                "http://schemas.openxmlformats.org/package/2006/relationships";
            Package InmemoryPackage = null;
            MemoryStream memStream = new MemoryStream();
            using (InmemoryPackage = Package.Open(memStream, FileMode.Create))
            {
                // add all parts (but not relationships)
                foreach (var xmlPart in doc.Root
                    .Elements()
                    .Where(p =>
                        (string)p.Attribute(pkg + "contentType") !=
                        "application/vnd.openxmlformats-package.relationships+xml"))
                {
                    string name = (string)xmlPart.Attribute(pkg + "name");
                    string contentType = (string)xmlPart.Attribute(pkg + "contentType");
                    if (contentType.EndsWith("xml"))
                    {
                        Uri u = new Uri(name, UriKind.Relative);
                        PackagePart part = InmemoryPackage.CreatePart(u, contentType,
                            CompressionOption.SuperFast);
                        using (Stream str = part.GetStream(FileMode.Create))
                        using (XmlWriter xmlWriter = XmlWriter.Create(str))
                            xmlPart.Element(pkg + "xmlData")
                                .Elements()
                                .First()
                                .WriteTo(xmlWriter);
                    }
                    else
                    {
                        Uri u = new Uri(name, UriKind.Relative);
                        PackagePart part = InmemoryPackage.CreatePart(u, contentType,
                            CompressionOption.SuperFast);
                        using (Stream str = part.GetStream(FileMode.Create))
                        using (BinaryWriter binaryWriter = new BinaryWriter(str))
                        {
                            string base64StringInChunks =
                           (string)xmlPart.Element(pkg + "binaryData");
                            char[] base64CharArray = base64StringInChunks
                                .Where(c => c != '\r' && c != '\n').ToArray();
                            byte[] byteArray =
                                System.Convert.FromBase64CharArray(base64CharArray,
                                0, base64CharArray.Length);
                            binaryWriter.Write(byteArray);
                        }
                    }
                }
                foreach (var xmlPart in doc.Root.Elements())
                {
                    string name = (string)xmlPart.Attribute(pkg + "name");
                    string contentType = (string)xmlPart.Attribute(pkg + "contentType");
                    if (contentType ==
                        "application/vnd.openxmlformats-package.relationships+xml")
                    {
                        // add the package level relationships
                        if (name == "/_rels/.rels")
                        {
                            foreach (XElement xmlRel in
                                xmlPart.Descendants(rel + "Relationship"))
                            {
                                string id = (string)xmlRel.Attribute("Id");
                                string type = (string)xmlRel.Attribute("Type");
                                string target = (string)xmlRel.Attribute("Target");
                                string targetMode =
                                    (string)xmlRel.Attribute("TargetMode");
                                if (targetMode == "External")
                                    InmemoryPackage.CreateRelationship(
                                        new Uri(target, UriKind.Absolute),
                                        TargetMode.External, type, id);
                                else
                                    InmemoryPackage.CreateRelationship(
                                        new Uri(target, UriKind.Relative),
                                        TargetMode.Internal, type, id);
                            }
                        }
                        else
                        // add part level relationships
                        {
                            string directory = name.Substring(0, name.IndexOf("/_rels"));
                            string relsFilename = name.Substring(name.LastIndexOf('/'));
                            string filename =
                                relsFilename.Substring(0, relsFilename.IndexOf(".rels"));
                            PackagePart fromPart = InmemoryPackage.GetPart(
                                new Uri(directory + filename, UriKind.Relative));
                            foreach (XElement xmlRel in
                                xmlPart.Descendants(rel + "Relationship"))
                            {
                                string id = (string)xmlRel.Attribute("Id");
                                string type = (string)xmlRel.Attribute("Type");
                                string target = (string)xmlRel.Attribute("Target");
                                string targetMode =
                                    (string)xmlRel.Attribute("TargetMode");
                                if (targetMode == "External")
                                    fromPart.CreateRelationship(
                                        new Uri(target, UriKind.Absolute),
                                        TargetMode.External, type, id);
                                else
                                    fromPart.CreateRelationship(
                                        new Uri(target, UriKind.Relative),
                                        TargetMode.Internal, type, id);
                            }
                        }
                    }
                }
                InmemoryPackage.Flush();
            }
            return memStream;
        }
