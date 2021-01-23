    internal void LoadTree(RadTreeView treeView, System.Collections.IEnumerable r)
        {
            var enumerable = r as object[] ?? r.Cast<object>().ToArray();
            LoadRootNodes(ref treeView, TreeNodeExpandMode.ServerSideCallBack, enumerable);
            treeView.NodeExpand += (s, e) =>
                {
                 if (e.Node.Nodes.Count == 0)
                   PopulateNodeOnDemand(e, 
                                        TreeNodeExpandMode.ServerSide,
                                        enumerable)
                };
        }
   
