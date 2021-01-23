    private void PopulateTreeView()
        {
            ListOfObjectsSorted = ListOfObjects.OrderBy(r => r.Group).ToList();
            var topNode = new TreeNode("Select all");
            treeView1.Nodes.Add(topNode);
            string currentGroup = ListOfObjectsSorted.First().Group;
            var treeNodes = new List<TreeNode>();
            var childNodes = new List<TreeNode>();
            foreach (Object obj in ListOfObjectsSorted )
            {
                if (currentGroup == rule.Group)
                    childNodes.Add(new TreeNode(obj.Name));
                else
                {
                    if (childNodes.Count > 0)
                    {
                        treeNodes.Add(new TreeNode(currentGroup, childNodes.ToArray()));
                        childNodes = new List<TreeNode>();
                    }
                    childNodes.Add(new TreeNode(obj.Name));
                    currentGroup = obj.Group;
                }
            }
            if (childNodes.Count > 0)
            {
                treeNodes.Add(new TreeNode(currentGroup, childNodes.ToArray()));
            }
            treeView1.Nodes[0].Nodes.AddRange(treeNodes.ToArray());
        }
