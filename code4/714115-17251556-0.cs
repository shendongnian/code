        // Add Node checked children into ArrayList
        private static void AddCheckedNodes(TreeNode node, ArrayList list) {
          if (node.Checked)
            list.Add(node);
    
          for (int i = 0; i < node.Nodes.Count; ++i)
            AddCheckedNodes(node.Nodes[i], list);
        }
    
        // Add TreeView checked nodes into ArrayList
        public static void AddCheckedNodes(TreeView value, ArrayList list) {
          if (Object.ReferenceEquals(null, value))
            throw new ArgumentNullException("value");
    
          if (Object.ReferenceEquals(null, list))
            throw new ArgumentNullException("list");
    
          for (int i = 0; i < value.Nodes.Count; ++i) 
            AddCheckedNodes(value.Nodes[i], list);
        }
    
       ...
     
       AddCheckedNodes(myTreeView, myArrayList);
