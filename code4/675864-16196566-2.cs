                internal class TreeNodeHierachy
        {
            public int Level { get; set; }
            public TreeNode Node { get; set; }
            public Guid Id { get; set; }
            public Guid ParentId { get; set; }
            public string RootText { get; set; }
        }
        private List<TreeNodeHierachy> overAllNodeList; 
        private void AddNodes(IEnumerable<string> data)
        {
            overAllNodeList = new List<TreeNodeHierachy>();
            foreach (var item in data)
            {
                var nodeList = new List<TreeNodeHierachy>();
                var split = item.Split('.');
                for (var i = 0; i < split.Count(); i++)
                {
                    var guid = Guid.NewGuid();
                    var parent = i == 0 ? null : nodeList.First(n => n.Level == i - 1);
                    var root = i == 0 ? null : nodeList.First(n => n.Level == 0);
                    nodeList.Add(new TreeNodeHierachy
                        {
                            Level = i,
                            Node = new TreeNode(split[i]) { Tag = guid },
                            Id = guid,
                            ParentId = parent != null ? parent.Id : Guid.Empty,
                            RootText = root != null ? root.RootText : split[i]
                        });
                }
                // figure out dups here
                if (!overAllNodeList.Any())
                {
                    overAllNodeList.AddRange(nodeList);
                }
                else
                {
                    nodeList = nodeList.OrderBy(x => x.Level).ToList();
                    for (var i = 0; i < nodeList.Count; i++)
                    {
                        var existingNode = overAllNodeList.FirstOrDefault(
                            n => n.Node.Text == nodeList[i].Node.Text && n.Level == nodeList[i].Level && n.RootText == nodeList[i].RootText);
                        if (existingNode != null && (i + 1) < nodeList.Count)
                        {
                            
                            nodeList[i + 1].ParentId = existingNode.Id;
                        }
                        else
                        {
                            overAllNodeList.Add(nodeList[i]);
                        }
                    }
                }
            }
            
            foreach (var treeNodeHierachy in overAllNodeList.Where(x => x.Level == 0))
            {
                treeView1.Nodes.Add(AddChildNodes(treeNodeHierachy));
            }
        }
        private TreeNode AddChildNodes(TreeNodeHierachy node)
        {
            var treeNode = node.Node;
            foreach (var treeNodeHierachy in overAllNodeList.Where(n => n.ParentId == node.Id))
            {
                treeNode.Nodes.Add(AddChildNodes(treeNodeHierachy));
            }
            return treeNode;
        }
        
        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //SearchActiveDirectoryWithCriteria("(mailnickname=TM418)");
            
            var test = new List<string>
                {
                    "John",
                    "Peter",
                    "Vanesa",
                    "Vanesa.New",
                    "Josh",
                    "Josh.New",
                    "Josh.New.Under",
                    "Josh.Old"
                };
            AddNodes(test);           
        }
