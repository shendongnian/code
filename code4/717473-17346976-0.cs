     public class FancyGridView : GridView
        {
    
            protected override void OnPreRender(EventArgs e)
            {
                base.OnPreRender(e);
                this.Page.ClientScript.RegisterClientScriptResource(
                    typeof(FancyGridView), "FancyCustomControls.Scripts.GridViewScript.js");
            }
    ...
    }
