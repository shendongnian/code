    if (!IsPostBack)
    {
         txtKey2.Text = "";
         txtKey2.BackColor = System.Drawing.ColorTranslator.FromHtml("#CCCCCC");
         txtKey2.Enabled = false;
    }
    
    ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "MyJSFunction", "EnableSelkey("+selKey1.SelectedValue+",1);", true);
