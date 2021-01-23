    private int _maxDepth = 5;
    public void loadFromDataTable(DataTable table, TreeView tree)
    {
        DataView view1 = new DataView(table);
        view1.RowFilter = "liv = 1";
    
        foreach (DataRowView dr in view1) 
        {
            TreeNode node = new TreeNode(dr["des"].ToString());
            buildTree(table, node, 2);
            tree.Nodes.Add(node);
        }
    }
    
    public void buildTree(DataTable table, TreeNode parent, int level)
    {
        if(level <= _maxDepth)
        {
            DataView view = new DataView(table);
            view.RowFilter = "liv = " + level + " AND cod LIKE '" + dr["cod"].ToString().Trim() + "%'";
    
            foreach (DataRowView dr in view) {
                TreeNode node = new TreeNode(dr["des"].ToString());
                buildTree(table, node, level+1);
                parent.Nodes.Add(node);
            }
        }
    }
