        /// <summary>
        /// Return true if <paramref name="allItems"/>
        /// contains one or more <paramref name="candidates"/>
        /// </summary>
        public static bool Contains<T>(IList<T> allItems, IEnumerable<T> candidates)
        {
            if (null == allItems)
                return false;
            if (null == candidates)
                return false;
            return allItems.Any(i => candidates.Contains(i));
        }
