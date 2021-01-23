    public interface ISourcePart
    {
        /// <summary>
        /// Gets the string representation of the kind of thing we're working with
        /// </summary>
        string Kind { get; }
        /// <summary>
        /// Gets the position this information is found at in the original source
        /// </summary>
        int Position { get; }
        
        /// <summary>
        /// Gets a representation of this data as Token objects
        /// </summary>
        /// <returns>An array of Token objects representing the data</returns>
        Token[] AsTokens();
    }
