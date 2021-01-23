     public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
    
            }
    
            protected void DDL_SelectedIndexChanged(object sender, EventArgs e)
            {
                var selectedValue = ((DropDownList)sender).SelectedValue;
                TextBox1.Text = selectedValue;
            }
        }
