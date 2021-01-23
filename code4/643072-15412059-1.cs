    using System;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        protected void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = ComboBox1.SelectedItem.Text;
        }
    }
