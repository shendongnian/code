    protected void Page_Load (object sender, EventArgs e)
    {
        if ( IsPostBack )
        {
            if ( ViewState["chb"] != null )
                CreateChb ();
        }
    }
    protected void show_Click(object sender, EventArgs e)
    {
        Response.Write(((CheckBox) content.FindControl("chb")).Text);
    }
    protected void add_Click(object sender, EventArgs e)
    {
        ViewState["chk"] = true;
        CreateChb ();
    }
    private void CreateChb ()
    {
        CheckBox chb = new CheckBox();
        chb.ID = "chb";
        chb.Text = "chb";
        content.Controls.Add(chb);
    }
