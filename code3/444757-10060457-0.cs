            var nodes = doc.DocumentNode.SelectNodes("//span[@class='advisory_link']//strong[1]");
            
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    string Description = node.InnerHtml;
                    return Description;
                }
            }
            return null;
