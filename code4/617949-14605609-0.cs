    List<string> collectExpandedNodes(TreeNodeCollection Nodes)
            {
                List<string> _lst = new List<string>();
                foreach (TreeNode checknode in Nodes)
                {
                    if (checknode.IsExpanded)
                        _lst.Add(checknode.Name);
                    if (checknode.Nodes.Count > 0)
                        _lst.AddRange(collectExpandedNodes(checknode.Nodes));
                }
                return _lst;
            }
