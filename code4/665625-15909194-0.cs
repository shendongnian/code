    using System.Linq;
    using System.Web.UI.WebControls;
    
    foreach (Control list in MainPanel.Controls.OfType<DropDownList>)
    {
        list.Items.Clear();
    }
