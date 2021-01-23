            protected void treeViewRearrange(RadTreeView tvw) {
            foreach (RadTreeNode menuItem in tvw.Nodes) {
                List<RadTreeNode> itemTypes = new List<RadTreeNode>();
                foreach (RadTreeNode item in menuItem.Nodes) {
                    foreach (RadTreeNode typeElement in item.Nodes) {
                        var type = itemTypes.FirstOrDefault(x => x.Text == typeElement.Text);
                        if (type == null) {
                            type = new RadTreeNode(typeElement.Text);
                            itemTypes.Add(type);
                        }
                        RadTreeNode copyOfitem = item.Clone();
                        // Hide all existing sub types
                        for (int i = 0; i < copyOfitem.Nodes.Count; i++) {
                            copyOfitem.Nodes[i].Visible = false;
                        }
                        type.Nodes.Add(copyOfitem);
                    }
                }
                menuItem.Nodes.Clear();
                menuItem.Nodes.AddRange(itemTypes);
                tvw.ExpandAllNodes();
            }
        }
