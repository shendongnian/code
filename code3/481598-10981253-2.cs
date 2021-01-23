    public void ExpandFirst(TreeNodeCollection nodes)
    {
       if (nodes.Count > 0)
       {
          nodes[0].Expand();
          ExpandFirst(nodes[0].Nodes);
       }
    }
