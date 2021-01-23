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
            for(int i = Children.Count - 1; i >= 0; i--)
            {
                if (Children[i].Remove(name))
                {
                    // Use a for-loop with index to remove the child right away.
                    Children.Remove(Children[i]);
                    // Extra remove handling
                    i--;
                }
            }
            // Remove condition.
            return this.Name.Contains(name);
        }
    }
