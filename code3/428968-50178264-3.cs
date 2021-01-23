    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    
    public partial class Control : UserControl
    {
        public List<string> Items { get; set; }
    
        protected override void OnPreRender(EventArgs e)
        {
            Repeater.DataSource = Items;
            Repeater.DataBind();
        }
    }
