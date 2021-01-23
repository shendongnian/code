    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    
    public partial class TestPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TestControl.DataBind();
        }
    
        protected List<string> Items = new List<string>() { "Hello", "world!", };
    }
