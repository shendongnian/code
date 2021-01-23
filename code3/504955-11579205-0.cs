        static void Main(string[] args)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml("<html><head></head><body><p>test</p><font><p><span><br></span></p></font></body></html");
            RemoveEmptyNodes(doc.DocumentNode);
        }
        static void RemoveEmptyNodes(HtmlNode containerNode)
         {
             if (containerNode.InnerText == null || containerNode.InnerText == string.Empty)
             {
                 containerNode.Remove();
             }
             else
             {
                 for (int i = containerNode.ChildNodes.Count - 1; i >= 0; i-- )
                 {
                     RemoveEmptyNodes(containerNode.ChildNodes[i]);
                 }
             }
          }
