    var data = @"<foo>
        <items>
            <itemToReplace>
                <itemContent />
            </itemToReplace>
        </items>
    </foo>";
            // Load your document
            var doc = XDocument.Parse(data);
            // Get the root
            var root = doc.Element("items");
            // Get all tags that you want to replace
            var repls = doc.Descendants("itemToReplace").ToList();
            // Iterate over
            foreach (var item in repls) {
                // prepare a new element as a replacement for your target.
                // Content will be the same as the content of the element being replaced.
                var newElement = new XElement("newElement", item.DescendantNodes());
                // add the element right after the tag to be replaced
                item.AddAfterSelf(newElement);
                // finally remove the tag.
                item.Remove();
            }
            MessageBox.Show(doc.ToString());
