    protected void Page_Load (object sender, EventArgs e)
    {
        if ( IsPostBack )
        {
            if ( Session["chb"] != null )
                CreateChb ();
        }
    }
    protected void show_Click(object sender, EventArgs e)
    {
        Response.Write(((CheckBox) content.FindControl("chb")).Text);
    }
    protected void add_Click(object sender, EventArgs e)
    {
        Session["chk"] = true;
        CreateChb ();
    }
    private void CreateChb ()
    {
        CheckBox chb = new CheckBox();
        chb.ID = "chb";
        chb.Text = "chb";
        content.Controls.Add(chb);
    }
