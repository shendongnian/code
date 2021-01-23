        class TreeBuilder
    {
        public int index,depth;
        public string text;
        public Dictionary<string,TreeBuilder> childs;
        public void addToTreeVeiw(System.Windows.Forms.TreeNode root, TreeBuilder tb) {
            foreach (string key in tb.childs.Keys) {
                System.Windows.Forms.TreeNode t = root.Nodes.Add(tb.childs[key].text);
                addToTreeVeiw(t, tb.childs[key]);
                
            }
        }
    }
