    public class ParseTree : ISourcePart
    {
        /// <summary>
        /// Creates a new ParseTree
        /// </summary>
        /// <param name="kind">The kind (name) of tree this is</param>
        /// <param name="nodes">The nodes the tree matches</param>
        /// <param name="position">The position in the source file this tree is located at</param>
        public ParseTree(string kind, IEnumerable<ISourcePart> nodes, int position)
        {
            Kind = kind;
            ParseNodes = nodes.ToList();
            Position = position;
        }
        public string Kind { get; private set; }
        public int Position { get; private set; }
        /// <summary>
        /// Gets the nodes that make up this parse tree
        /// </summary>
        public IList<ISourcePart> ParseNodes { get; internal set; }
        public Token[] AsTokens()
        {
            return ParseNodes.SelectMany(x => x.AsTokens()).ToArray();
        }
    }
    public class ParseNode : ISourcePart
    {
        /// <summary>
        /// Creates a new ParseNode
        /// </summary>
        /// <param name="sourcePart">The data that was matched to create this node</param>
        /// <param name="tag">The tag data (if any) associated with the node</param>
        public ParseNode(ISourcePart sourcePart, string tag)
        {
            SourcePart = sourcePart;
            Tag = tag;
        }
        public string Kind { get { return SourcePart.Kind; } }
        /// <summary>
        /// Gets the tag associated with the matched data
        /// </summary>
        public string Tag { get; private set; }
        /// <summary>
        /// Gets the data that was matched to create this node
        /// </summary>
        public ISourcePart SourcePart { get; private set; }
        public int Position { get { return SourcePart.Position; } }
        public Token[] AsTokens()
        {
            return SourcePart.AsTokens();
        }
    }
