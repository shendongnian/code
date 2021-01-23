            schemaDocument.LoadXml(codesXML);
            var xmlNameSpaceManager = new XmlNamespaceManager(schemaDocument.NameTable);
            if (schemaDocument.DocumentElement != null)
                xmlNameSpaceManager.AddNamespace("x", schemaDocument.DocumentElement.NamespaceURI);
            var codesNode = schemaDocument.SelectSingleNode(@"/x:integration-engine-codes/x:code-categories/x:code-category/x:codes", xmlNameSpaceManager);
            var codeNode = codesNode.ChildNodes.Item(Convert.ToInt32(index) - 1);
            if (codeNode == null || codeNode.ParentNode == null)
            {
                throw new Exception("Invalid node found");
            }
            codesNode.RemoveChild(codeNode);
            return schemaDocument.OuterXml;
