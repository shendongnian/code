    public static void Load(TreeView tree, string filename)
    {
        using (var file = File.Open(filename, FileMode.OpenOrCreate))
        {
            if (file.Length.Equals(0))
                return;
            var bf = new BinaryFormatter();
            var obj = bf.Deserialize(file);
            var nodeList = (obj as IEnumerable<TreeNode>).ToArray();
            tree.Nodes.AddRange(nodeList);
        }
        
    }
