    class XmlMerger
    {
        public XDocument Merge(XDocument first, XDocument second)
        {
            return new XDocument(MergeElements(first.Root, second.Root));
        }
        private XElement MergeElements(XElement first, XElement second)
        {
            if (first == null)
                return second;
            if (second == null)
                return first;
            if (first.Name != second.Name)
                throw new InvalidOperationException();
            var firstId = (string)first.Attribute("id");
            var secondId = (string)second.Attribute("id");
            // different ids
            if (firstId != secondId)
                throw new InvalidOperationException();
            var result = new XElement(first.Name);
            var attributeNames = first.Attributes()
                .Concat(second.Attributes())
                .Select(a => a.Name)
                .Distinct();
            foreach (var attributeName in attributeNames)
                result.Add(
                    MergeAttributes(
                        first.Attribute(attributeName),
                        second.Attribute(attributeName)));
            // text-only elements
            if (first.Nodes().OfType<XText>().Any() ||
                first.Nodes().OfType<XText>().Any())
            {
                var firstText = first.Nodes().OfType<XText>().FirstOrDefault();
                var secondText = second.Nodes().OfType<XText>().FirstOrDefault();
                // we're not handling mixed elements
                if (first.Nodes().Any(n => n != firstText) ||
                    second.Nodes().Any(n => n != secondText))
                    throw new InvalidOperationException();
                result.Add(MergeTexts(firstText, secondText));
            }
            else
            {
                var elementNames = first.Elements()
                    .Concat(second.Elements())
                    .Select(e => e.Name)
                    .Distinct();
                foreach (var elementName in elementNames)
                {
                    var ids = first.Elements(elementName)
                        .Concat(second.Elements(elementName))
                        .Select(e => (string)e.Attribute("id"))
                        .Distinct();
                    foreach (var id in ids)
                    {
                        XElement firstElement = first.Elements(elementName)
                            .SingleOrDefault(e => (string)e.Attribute("id") == id);
                        XElement secondElement = second.Elements(elementName)
                            .SingleOrDefault(e => (string)e.Attribute("id") == id);
                        result.Add(MergeElements(firstElement, secondElement));
                    }
                }
            }
            return result;
        }
        private XAttribute MergeAttributes(XAttribute first, XAttribute second)
        {
            if (first == null)
                return second;
            if (second == null)
                return first;
            if (first.Name != second.Name)
                throw new InvalidOperationException();
            if (first.Value == second.Value)
                return new XAttribute(first);
            // can't merge attributes with different values
            throw new InvalidOperationException();
        }
        private XText MergeTexts(XText first, XText second)
        {
            if (first == null)
                return second;
            if (second == null)
                return first;
            if (first.Value == second.Value)
                return new XText(first);
            // can't merge texts with different values
            throw new InvalidOperationException();
        }
    }
