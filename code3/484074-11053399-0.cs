            string rawHtml = "<p><strong><span>1.0 Purpose</span></strong></p><p><span>The role</span></p><p><span>NOTE: Defined...</span></p>"; 
 
            List<HtmlNode> nodesToRemove = new List<HtmlNode>();
            HtmlDocument doc = new HtmlDocument();
            HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Empty;
            doc.LoadHtml(rawHtml);
            doc.OptionWriteEmptyNodes = true;
            HtmlNode linebreak1 = doc.CreateElement("br");
            HtmlNode linebreak2 = doc.CreateElement("br");
            var paragraphTags = doc.DocumentNode.SelectNodes("p");
            for (int i = 0; i < paragraphTags.Count; i++)
            {
                if (i > 0)
                {
                    doc.DocumentNode.InsertBefore(linebreak1, paragraphTags[i]);
                    doc.DocumentNode.InsertBefore(linebreak2, paragraphTags[i]);
                }
                doc.DocumentNode.InsertBefore(HtmlNode.CreateNode(paragraphTags[i].InnerHtml), paragraphTags[i]);
                nodesToRemove.Add(paragraphTags[i]);
            }
            foreach (var nodeToRemove in nodesToRemove)
                doc.DocumentNode.RemoveChild(nodeToRemove);
