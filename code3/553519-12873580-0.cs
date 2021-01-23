        /// <summary>
        ///   Show changes between the working directory and the index.
        /// </summary>
        /// <param name = "paths">The list of paths (either files or directories) that should be compared.</param>
        /// <returns>A <see cref = "TreeChanges"/> containing the changes between the working directory and the index.</returns>
        public virtual TreeChanges Compare(IEnumerable<string> paths = null)
