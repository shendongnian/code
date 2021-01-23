    // start by getting the root
    private void build_file_list(List<Entry> entries)
    {
        TreeNode root;
        string[] pathbits;
        for (int i = 0; i < entries.Count(); i++)
        {
            pathbits = entries[i].name.Split(Path.DirectorySeparatorChar);
            root = get_root(pathbits[0]);
            add_path(root, pathbits);
        }
    }
    // returns existing node or creates a new one as needed
    private TreeNode get_root(string key)
    {
        if (explorer_view.Nodes.ContainsKey(key))
            return explorer_view.Nodes[key];
        else
            return explorer_view.Nodes.Add(key, key);
    }
    
    // now we have our root so we can start building the rest
    private void add_path(TreeNode node, string[] pathbits)
    {
        for (int i = 1; i < pathbits.Count(); i++)
            node = add_node(node, pathbits[i]);
    }
        
    // just recursively build nodes until end of file path
    private TreeNode add_node(TreeNode node, string key)
    {
        if (node.Nodes.ContainsKey(key))
            return node.Nodes[key];
        else
            return node.Nodes.Add(key, key);
    }
