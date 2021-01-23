    public class Node
    {
        public string Name { get; set; }
        public bool IsDirectory { get; set; }
        public List<Node> Children = new List<Node>();
        internal void AddChildren(string f)
        {
            var dirs = Path.GetDirectoryName(f);
            if (string.IsNullOrEmpty(dirs))
            {
                // we are adding a file
                var file = Path.GetFileName(f);
                Children.Add(new Node {Name = file, IsDirectory = false});
            }
            else
            {
                // we are adding a directory
                var firstDir = dirs.Split(Path.DirectorySeparatorChar)[0];
                var childNode = Children.FirstOrDefault(d => d.Name == firstDir);
                if (childNode == null)
                {
                    childNode = new Node {Name = firstDir, IsDirectory = true};
                    Children.Add(childNode);
                }
                var subPath = f.Substring(firstDir.Length + 1);
                childNode.AddChildren(subPath);
            }
        }
    }
