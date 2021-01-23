    public class CustomTreeView : TreeView {
    
        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e) {
           base.OnNodeMouseClick(e);
           
           // your stuff
           // Call myself the AfterCheck event
           base.OnAfterCheck(new TreeViewEventArgs(e.Node, TreeViewAction.ByMouse));
        }
        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
           // do nothing   
        }
    }
