    using System;
    public partial class scripts_script
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Response.ContentType = "application/x-javascript";
        }
    }
