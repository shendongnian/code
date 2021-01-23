        public static IEnumerable<TreeNode>
                               GetAllCheckedChildNodes(TreeNode node)
        {
            foreach (TreeNode tmpNode in node.Nodes)
            {
                if (tmpNode.Checked)
                {
                    yield return tmpNode;
                }
                foreach (var x in GetAllCheckedChildNodes(tmpNode))
                {
                    yield return x;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var checkedNodes = GetAllheckedChildNodes(MyRootNode);
            foreach (TreeNode checkedNode in checkedNodes)
            {
                checkedNode.BackColor = Color.Black;
            }
        }
