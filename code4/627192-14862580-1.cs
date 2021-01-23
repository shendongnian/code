        public static IEnumerable<T> FlattenedTree<T>(this T node, Func<T, IEnumerable<T>> getter)
        {
            yield return node;
            var children = getter(node);
            if(children != null)
            {
                foreach (T child in children)
                {
                    foreach (T relative in FlattenedTree(child, getter))
                    {
                        yield return relative;
                    }
                }
            }
        }
