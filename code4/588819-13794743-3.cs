        static void Main(string[] args)
        {
            int maxLength = 9;
            string input = @"
                some more text some more text 
                <div>
                    <p>some text</p>
                    <p>some more text some more text some more text some more text some more text</
                </div>";
            var doc = new HtmlDocument();
            doc.LoadHtml(input);
            // Get text nodes with the appropriate running total
            var acc = 0;
            var nodes = doc.DocumentNode
                .Descendants()
                .Where(n => n.NodeType == HtmlNodeType.Text && n.InnerText.Trim().Length > 0)
                .Select(n => 
                {
                    var length = n.InnerText.Trim().Length;
                    acc += length;
                    return new { Node = n, TotalLength = acc, NodeLength = length }; 
                })
                .TakeWhile(n => (n.TotalLength - n.NodeLength) < maxLength)
                .ToList();
            // Select element nodes we intend to keep
            var nodesToKeep = nodes
                .SelectMany(n => n.Node.AncestorsAndSelf()
                    .Where(m => m.NodeType == HtmlNodeType.Element));
            // Select and remove element nodes we don't need
            var nodesToDrop = doc.DocumentNode
                .Descendants()
                .Where(m => m.NodeType == HtmlNodeType.Element)
                .Except(nodesToKeep)
                .ToList();
            
            foreach (var r in nodesToDrop)
                r.Remove();
            // Shorten the last node as required
            var lastNode = nodes.Last();
            var lastNodeText = lastNode.Node;
            var text = lastNodeText.InnerText.Trim().Substring(0,
                    lastNode.NodeLength - lastNode.TotalLength + maxLength);
            lastNodeText
                .ParentNode
                .ReplaceChild(HtmlNode.CreateNode(text), lastNodeText);
            
            doc.Save(Console.Out);
        }
