    using System.Linq;
    using System.Web.UI.WebControls;
    
    foreach (DropDownList list in MainPanel.Controls.OfType<DropDownList>())
    {
        list.Items.Clear();
    }
