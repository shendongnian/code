        internal class TreeNodeHierachy
        {
            public int Level { get; set; }
            public TreeNode Node { get; set; }
        }
        private void AddNodes(IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                var nodeList = new List<TreeNodeHierachy>();
                var split = item.Split('.');
                for (var i = 0; i < split.Count(); i++)
                {
                    nodeList.Add(new TreeNodeHierachy
                        {
                            Level = i,
                            Node = new TreeNode(split[i])
                        });
                }
                var root = nodeList.First(n => n.Level == 0).Node;
                foreach (var tNode in treeView1.Nodes.Cast<TreeNode>().Where(tNode => tNode.Text == root.Text))
                {
                    treeView1.Nodes.Remove(tNode);
                    break;
                }
                treeView1.Nodes.Add(AddChildNodes(root, nodeList.Where(n => n.Level > 0).ToList(), 0));
            }
        }
        private TreeNode AddChildNodes(TreeNode node, List<TreeNodeHierachy> nodes, int level)
        {
            var newLevel = level + 1;
            if (!nodes.Any())
            {
                return node;
            }
            var newNode = nodes.FirstOrDefault(n => n.Level == newLevel).Node;
            if (newNode != null)
            {
                node.Nodes.Add(AddChildNodes(newNode, nodes.Where(n => n.Level > newLevel).ToList(), newLevel));
            }
            return node;
        }
        
        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var test = new List<string>
                {
                    "John",
                    "Peter",
                    "Vanesa",
                    "Vanesa.New",
                    "Josh",
                    "Josh.New",
                    "Josh.New.Under"
                };
            AddNodes(test);            
        }
