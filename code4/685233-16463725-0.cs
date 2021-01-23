    using System.Web.UI.WebControls;
    namespace CSASPNETInheritingFromTreeNode
    {
        public class CustomTreeView : TreeView
        {
    
            protected override TreeNode CreateNode()
            {
                return new CustomTreeNode(this, false);
            }
        }
    
        public class CustomTreeNode : TreeNode
        {
    
            public object Tag { get; set; }
    
            public CustomTreeNode() : base()
            {
            }
    
            public CustomTreeNode(TreeView owner, bool isRoot) : base(owner, isRoot)
            {
            }
    
    
            protected override void LoadViewState(object state)
            {
                object[] arrState = state as object[];
    
                this.Tag = arrState[0];
                base.LoadViewState(arrState[1]);
            }
    
    
            protected override object SaveViewState()
            {
                object[] arrState = new object[2];
                arrState[1] = base.SaveViewState();
                arrState[0] = this.Tag;
    
                return arrState;
            }
        }
    }
