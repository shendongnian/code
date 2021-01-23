        public class Node<T>
        {
            internal Node() { }
            public T Item { get; internal set; }
            public int Level { get; internal set; }
            public Node<T> Parent { get; internal set; }
            public IList<Node<T>> Children { get; internal set; }
        }
        public static IEnumerable<Node<T>> ToHierarchy<T>(
            this IEnumerable<T> source,
            Func<T, bool> startWith,
            Func<T, T, bool> connectBy)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (startWith == null) throw new ArgumentNullException("startWith");
            if (connectBy == null) throw new ArgumentNullException("connectBy");
            return source.ToHierarchy(startWith, connectBy, null);
        }
        private static IEnumerable<Node<T>> ToHierarchy<T>(
            this IEnumerable<T> source,
            Func<T, bool> startWith,
            Func<T, T, bool> connectBy,
            Node<T> parent)
        {
            int level = (parent == null ? 0 : parent.Level + 1);
            var roots = from item in source
                        where startWith(item)
                        select item;
            foreach (T value in roots)
            {
                var children = new List<Node<T>>();
                var newNode = new Node<T>
                {
                    Level = level,
                    Parent = parent,
                    Item = value,
                    Children = children.AsReadOnly()
                };
                T tmpValue = value;
                children.AddRange(source.ToHierarchy(possibleSub => connectBy(tmpValue, possibleSub), connectBy, newNode));
                yield return newNode;
            }
        }
