    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CustomTreeView runat=server></{0}:CustomTreeView>")]
    public class CustomTreeView : TreeView
    {
        protected override TreeNode CreateNode()
        {
            // Tree node will get its members populated with the data from VIEWSTATE
            return new CustomTreeNode();
        }
    }
