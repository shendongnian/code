    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class test6 : System.Web.UI.Page
    {
        protected void button_Click(object sender, EventArgs e)
        {
            Label1.Text = "Current time in ticks: " + DateTime.Now.Ticks.ToString();
        }
    }
