    /// <summary>
    ///     Adds functionality to all entities derived from the RecursiveEntity base class.
    /// </summary>
    public static class RecursiveEntityEx
    {
        /// <summary>
        ///     Adds a new child Entity to a parent Entity.
        /// </summary>
        /// <typeparam name="T">The type of recursive entity to associate with.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="child">The child.</param>
        /// <returns>The parent Entity.</returns>
        public static T AddChild<T>(this T parent, T child)
            where T : RecursiveEntity<T>
        {
            child.Parent = parent;
            if (parent.Children == null)
                parent.Children = new HashSet<T>();
            parent.Children.Add(child);
            return parent;
        }
        /// <summary>
        ///     Adds child Entities to a parent Entity.
        /// </summary>
        /// <typeparam name="T">The type of recursive entity to associate with.</typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="children">The children.</param>
        /// <returns>The parent Entity.</returns>
        public static T AddChildren<T>(this T parent, IEnumerable<T> children)
            where T : RecursiveEntity<T>
        {
            children.ToList().ForEach(c => parent.AddChild(c));
            return parent;
        }
    }
