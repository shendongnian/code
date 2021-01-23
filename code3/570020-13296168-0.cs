    void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             //populate drop down here
             if(Session["SelectedItem"] != null)
             {
                  dropDown.SelectedValue = Session["SelectedItem"].ToString();
                  Session["SelectedItem"] = null;
             }
       }
    }
