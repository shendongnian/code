    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TreeView1.Nodes.Add(new TreeNode("Node1"));
                TreeView1.Nodes[0].ChildNodes.Add(new TreeNode("ChildNode"));
            }
    
        }
    
    
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            Response.Write(TreeView1.SelectedNode.Text);
        }
    }
