    private void Form1_Load(object sender, EventArgs e)
    {
        var treeNode = new TreeNode("Sea Drive");
        treeView1.Nodes.Add(treeNode);
    
        ThreadPool.QueueUserWorkItem(_ => TraverseDirectory("C:\\", treeNode));
    }
       
    private static readonly string DirectorySeparatorString = Path.DirectorySeparatorChar.ToString();
    
    private void TraverseDirectory(string initialDirectoryPath, TreeNode initialTreeNode)
    {
        var initialTuples = new[] {Tuple.Create(initialDirectoryPath, initialTreeNode)};
        var directoryQueue = new Queue<Tuple<string, TreeNode>>(initialTuples);
    
        while (directoryQueue.Any())
        {
            var tuple = directoryQueue.Dequeue();
            var parentDirectoryPath = tuple.Item1;
            var parentTreeNode = tuple.Item2;
    
            try
            {
                var treeNodes = new List<TreeNode>();
                var directories = Directory.EnumerateDirectories(parentDirectoryPath);
    
                foreach (var directoryPath in directories)
                {
                    var lastDirectorySeparator = directoryPath.LastIndexOf(DirectorySeparatorString);
                    var directoryName = directoryPath.Substring(lastDirectorySeparator + 1);
    
                    // Add the tree node to our list of child 
                    // nodes, for an eventual call to AddRange
                    var treeNode = new TreeNode(directoryName);
                    treeNodes.Add(treeNode);
    
                    // We have to go deeper
                    directoryQueue.Enqueue(Tuple.Create(directoryPath, treeNode));
                }
    
                // Run this operation on the main thread
                Invoke((Action)(() => parentTreeNode.Nodes.AddRange(treeNodes.ToArray())));
            }
            catch (Exception exception)
            {
                Trace.Write(exception);
            }
        }
    }
