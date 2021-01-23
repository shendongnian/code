    public class CustomTreeNode : TreeNode
    {
        protected override void RenderPreText(HtmlTextWriter writer)
        {
           writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "green");
        }
    }
