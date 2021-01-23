        public partial class TestParser
        {
            C<ParseTree> parseTreeContainer = new C<ParseTree>() { Value = new ParseTree("root", null) };
            public ParseTree Tree
            {
                get
                {
                    return parseTreeContainer.Value;
                }
                set
                {
                    parseTreeContainer.Value = value;
                }
            }
            partial void CreateTreeAdaptor(ref ITreeAdaptor adaptor)
            {
                adaptor = new ParseAdaptor(this.parseTreeContainer);
            }
            partial void EnterRule(string ruleName, int ruleIndex)
            {
                ParseTree child = new ParseTree(ruleName, Tree);
                ParseTree parent = Tree;
                parent.Children.Add(child);
                Tree = child;
            }
            partial void LeaveRule(string ruleName, int ruleIndex)
            {
                Tree = Tree.Parent;
            }
            
        }
