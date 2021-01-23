    protected override void OnInit(EventArgs e)
    {
         if (Page.IsPostBack)
         {
             string id = Request.Form[TextBox1.ClientID].ToString();
             GenerateDynamicControls(id);
         }
    }
