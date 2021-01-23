    public class Tree
    {
        private static Random rand = new Random();
        public List<Tree> Children = new List<Tree>();
        public Tree Parent;
        public string Name;
        public Tree(Tree parent)
        {
            Parent = parent;
            Name = rand.Next(10000).ToString();
        }
        // Removing without tree traversal.
        public void DeleteParent()
        {
            this.Parent.Parent.Children.Remove(this.Parent);
        }
        public bool Remove(string name)
        {
            List<Tree> remainder = new List<Tree>();
            foreach (Tree child in Children)
            {
                if (!child.Remove(name))
                {
                    // Use a for-loop with index to remove the child right away.
                    remainder.Add(child);
                }
            }
            // Only children that we want remain.
            this.Children = remainder;
            // Remove condition.
            return this.Name.Contains(name);
        }
    }
