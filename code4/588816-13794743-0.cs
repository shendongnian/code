        static void Main(string[] args)
        {
            int maxLength = 50;
            string input = @"
                <div id ='1'>
                    <p>some text</p>
                    <p>foo some more text some more text some more text some more text some more text</p>
                    <div>
                        <p>ba some more text some more text some more text some more text some more text</p>
                        <p>b some more text some more text some more text some more text some more text</p>
                    </div>
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
                    acc += n.InnerText.Trim().Length; 
                    return new { Node = n, Length = acc }; 
                })
                .TakeWhile(n => (n.Length - n.Node.InnerText.Trim().Length) <= maxLength)
                .ToList();
            // Select element nodes we intend to keep
            var nodesToKeep = nodes
                .SelectMany(n => n.Node.AncestorsAndSelf().Where(m => m.NodeType == HtmlNodeType.Element));
            
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
            lastNode
                .Node
                .ParentNode
                .ReplaceChild(HtmlNode.CreateNode(lastNodeText.InnerText.Substring(0, 
                    lastNodeText.InnerText.Trim().Length - lastNode.Length + maxLength)), lastNode.Node);
            
            doc.Save(Console.Out);
        }
