    private static void FixParenthesis(ref IList<ISourcePart> items)
    {
        //Iterate through the set we're examining
        for (var i = 0; i < items.Count; ++i)
        {
            var parseNode = items[i] as ParseNode;
            //If we've got a parse node...
            if (parseNode != null)
            {
                var nodeTree = parseNode.SourcePart as ParseTree;
                //If the parse node represents a parse tree...
                if (nodeTree != null)
                {
                    //Fix parenthesis within the tree
                    var nodes = nodeTree.ParseNodes;
                    FixParenthesis(ref nodes);
                    nodeTree.ParseNodes = nodes;
                }
                //If this parse node required parenthesis, replace the subtree and add them
                if (parseNode.Tag == ParenthesisRequiredElement)
                {
                    var nodeContents = parseNode.AsTokens();
                    var combined = string.Join(string.Empty, nodeContents.OrderBy(x => x.Position).Select(x => x.Value));
                    items[i] = Token.Create(parseNode.Kind, string.Format("({0})", combined), parseNode.Position);
                }
                continue;
            }
            var parseTree = items[i] as ParseTree;
            //If we've got a parse tree...
            if (parseTree != null)
            {
                //Fix parenthesis within the tree
                var nodes = parseTree.ParseNodes;
                FixParenthesis(ref nodes);
                parseTree.ParseNodes = nodes;
            }
        }
    }
