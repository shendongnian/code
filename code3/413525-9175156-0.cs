    var data = @"<foo>
        <items>
            <itemToReplace>
                <itemContent />
            </itemToReplace>
        </items>
    </foo>";
            var doc = XDocument.Parse(data);
            var root = doc.Element("items");
            var repls = doc.Descendants("itemToReplace").ToList();
            var newEls = new List<XElement>();
            foreach (var item in repls) {
                var newElement = new XElement("newElement", item.DescendantNodes());
                item.AddAfterSelf(newElement);
                item.Remove();
            }
            MessageBox.Show(doc.ToString());
