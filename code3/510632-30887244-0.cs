    class TreeViewItem : TreeNode
    {
        // public new string Text;  Remove this so you don't call it
        public TreeViewItem(){
            this.Text = "asd";
        }
    
        //Treeview doesn't seem to use this
        public override string ToString()
        {
            return "asd";
        }
    }
