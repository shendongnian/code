    public class ParseTreeDefinition
    {
        /// <summary>
        /// The set of parse node definitions that constitute an initial match to the parse tree
        /// </summary>
        private readonly IList<ParseNodeDefinition> _initialNodeOptions;
        /// <summary>
        /// Creates a new ParseTreeDefinition
        /// </summary>
        /// <param name="name">The name to give to parse trees generated from full matches</param>
        public ParseTreeDefinition(string name)
        {
            _initialNodeOptions = new List<ParseNodeDefinition>();
            Name = name;
        }
        /// <summary>
        /// Gets the set of parse node definitions that constitute an initial match to the parse tree
        /// </summary>
        public IEnumerable<ParseNodeDefinition> InitialNodeOptions { get { return _initialNodeOptions; } }
        /// <summary>
        /// Gets the name of the ParseTreeDefinition
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Adds an option for a named node to follow this one in the parse tree the node is a part of
        /// </summary>
        /// <param name="matchItemsNamed">The name of the item to be matched</param>
        /// <returns>The ParseNodeDefinition that has been added</returns>
        public ParseNodeDefinition AddOption(string matchItemsNamed)
        {
            return AddOption(matchItemsNamed, string.Empty, false);
        }
        /// <summary>
        /// Adds an option for a named node to follow this one in the parse tree the node is a part of
        /// </summary>
        /// <param name="matchItemsNamed">The name of the item to be matched</param>
        /// <param name="tag">The tag to associate with matched items</param>
        /// <returns>The ParseNodeDefinition that has been added</returns>
        public ParseNodeDefinition AddOption(string matchItemsNamed, string tag)
        {
            return AddOption(matchItemsNamed, tag, false);
        }
        /// <summary>
        /// Adds an option for a named node to follow this one in the parse tree the node is a part of
        /// </summary>
        /// <param name="matchItemsNamed">The name of the item to be matched</param>
        /// <param name="tag">The tag to associate with matched items</param>
        /// <param name="isValidEnd">Whether or not the element is a valid end to the parse tree</param>
        /// <returns>The ParseNodeDefinition that has been added</returns>
        public ParseNodeDefinition AddOption(string matchItemsNamed, string tag, bool isValidEnd)
        {
            var node = ParseNodeDefinition.Create(matchItemsNamed, tag, isValidEnd);
            _initialNodeOptions.Add(node);
            return node;
        }
        /// <summary>
        /// Adds an option for a named node to follow this one in the parse tree the node is a part of
        /// </summary>
        /// <param name="matchItemsNamed">The name of the item to be matched</param>
        /// <param name="isValidEnd">Whether or not the element is a valid end to the parse tree</param>
        /// <returns>The ParseNodeDefinition that has been added</returns>
        public ParseNodeDefinition AddOption(string matchItemsNamed, bool isValidEnd)
        {
            return AddOption(matchItemsNamed, string.Empty, isValidEnd);
        }
        /// <summary>
        /// Attempts to follow a particular branch in the parse tree from a given starting point in a set of source parts
        /// </summary>
        /// <param name="parts">The set of source parts to attempt to match in</param>
        /// <param name="startIndex">The position to start the matching attempt at</param>
        /// <param name="required">The definition that must be matched for the branch to be followed</param>
        /// <param name="nodes">The set of nodes that have been matched so far</param>
        /// <returns>true if the branch was followed to completion, false otherwise</returns>
        private static bool FollowBranch(IList<ISourcePart> parts, int startIndex, ParseNodeDefinition required, ICollection<ParseNode> nodes)
        {
            if (parts[startIndex].Kind != required.MatchItemsNamed)
            {
                return false;
            }
            nodes.Add(new ParseNode(parts[startIndex], required.Tag));
            return parts.Count > (startIndex + 1) && required.NextNodeOptions.Any(x => FollowBranch(parts, startIndex + 1, x, nodes)) || required.IsValidEnd;
        }
        /// <summary>
        /// Attempt to match the parse tree definition against a set of source parts
        /// </summary>
        /// <param name="parts">The source parts to match against</param>
        /// <returns>true if the parse tree was matched, false otherwise. parts is updated by this method to consolidate matched nodes into a ParseTree</returns>
        public bool Parse(ref IList<ISourcePart> parts)
        {
            var partsCopy = parts.ToList();
            for (var i = 0; i < parts.Count; ++i)
            {
                var tree = new List<ParseNode>();
                if (InitialNodeOptions.Any(x => FollowBranch(partsCopy, i, x, tree)))
                {
                    partsCopy.RemoveRange(i, tree.Count);
                    partsCopy.Insert(i, new ParseTree(Name, tree.ToArray(), tree[0].Position));
                    parts = partsCopy;
                    return true;
                }
            }
            return false;
        }
    }
