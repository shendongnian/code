    public class ParseNodeDefinition
    {
        /// <summary>
        /// The set of parse node definitions that could be transitioned to from this one
        /// </summary>
        private readonly IList<ParseNodeDefinition> _nextNodeOptions;
        /// <summary>
        /// Creates a new ParseNodeDefinition
        /// </summary>
        private ParseNodeDefinition()
        {
            _nextNodeOptions = new List<ParseNodeDefinition>();
        }
        /// <summary>
        /// Gets whether or not this definition is an acceptable ending point for the parse tree
        /// </summary>
        public bool IsValidEnd { get; private set; }
        /// <summary>
        /// Gets the name an item must have for it to be matched by this definition
        /// </summary>
        public string MatchItemsNamed { get; private set; }
        /// <summary>
        /// Gets the set of parse node definitions that could be transitioned to from this one
        /// </summary>
        public IEnumerable<ParseNodeDefinition> NextNodeOptions
        {
            get { return _nextNodeOptions; }
        }
        /// <summary>
        /// Gets or sets the tag that will be associated with the data if matched
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Creates a new ParseNodeDefinition matching items with the specified name/kind.
        /// </summary>
        /// <param name="matchItemsNamed">The name of the item to be matched</param>
        /// <param name="tag">The tag to associate with matched items</param>
        /// <param name="isValidEnd">Whether or not the element is a valid end to the parse tree</param>
        /// <returns>A ParseNodeDefinition capable of matching items of the given name</returns>
        public static ParseNodeDefinition Create(string matchItemsNamed, string tag, bool isValidEnd)
        {
            return new ParseNodeDefinition { MatchItemsNamed = matchItemsNamed, Tag = tag, IsValidEnd = isValidEnd };
        }
        public ParseNodeDefinition AddOption(string matchItemsNamed)
        {
            return AddOption(matchItemsNamed, string.Empty, false);
        }
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
            var node = Create(matchItemsNamed, tag, isValidEnd);
            _nextNodeOptions.Add(node);
            return node;
        }
        public ParseNodeDefinition AddOption(string matchItemsNamed, bool isValidEnd)
        {
            return AddOption(matchItemsNamed, string.Empty, isValidEnd);
        }
        /// <summary>
        /// Links the given node as an option for a state to follow this one in the parse tree this node is a part of
        /// </summary>
        /// <param name="next">The node to add as an option</param>
        public void LinkTo(ParseNodeDefinition next)
        {
            _nextNodeOptions.Add(next);
        }
    }
