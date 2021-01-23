    public static class GroupEnumerable
    {
        public static Group BuildTree(this IEnumerable<Group> source)
        {
            var groups = source.GroupBy(i => i.ParentID);
            Group root = groups.FirstOrDefault(g => g.Key.HasValue == false).SingleOrDefault();
            if (root != null)
            {
                var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
                AddChildren(root, dict);
            }
            else
            {
                throw new ArgumentException("No root node found.");
            }
            return root;
        }
        private static void AddChildren(Group node, IDictionary<int, List<Group>> source)
        {
            if (source.ContainsKey(node.ID))
            {
                node.Children = source[node.ID];
                for (int i = 0; i < node.Children.Count; i++)
                    AddChildren(node.Children[i], source);
            }
        }
    }
