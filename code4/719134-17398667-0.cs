    public static class Exensions
    {
        /// <summary>
        /// Traverses the visual tree for a <see cref="DependencyObject"/> looking for a parent of a given type.
        /// </summary>
        /// <param name="targetObject">The object who's tree you want to search.</param>
        /// <param name="targetType">The type of parent control you're after</param>
        /// <returns>
        ///     A reference to the parent object or null if none could be found with a matching type.
        /// </returns>
        public static DependencyObject FindParent(this DependencyObject targetObject, Type targetType)
        {
            DependencyObject results = null;
            
            if (targetObject != null && targetType != null)
            {
                // Start looking form the target objects parent and keep looking until we either hit null
                // which would be the top of the tree or we find an object with the given target type.
                results = VisualTreeHelper.GetParent(targetObject);
                while (results != null && results.GetType() != targetType) results = VisualTreeHelper.GetParent(results);
            }
            return results;
        }
    }
