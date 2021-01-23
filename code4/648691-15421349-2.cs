        public IEnumerable<T> GetDescendents<T>(T parent, Func<T, IEnumerable<T>> childSelector)
        {
            yield return parent;
            foreach (var child in childSelector(parent))
            {
                foreach (var grandChild in GetDescendents(child, childSelector))
                {
                    yield return grandChild;
                }
            }
        }
