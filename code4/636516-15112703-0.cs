    public void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["addmoreEdu"] != null)
        {
            myCount = (int)ViewState["addmoreEdu"];
        }
       
        for (int i = 0; i < myCount; i++)
        {
            TextBox txtboxcustom = new TextBox();
            Literal newlit = new Literal();
            newlit.Text = "<br /><br />";
            txtboxcustom.ID = "txtBoxcustom" + i.ToString();
            myPlaceHolder.Controls.Add(txtboxcustom);
            myPlaceHolder.Controls.Add(newlit);
        }
    }
    
    public void addmoreCustom_Click(object sender, EventArgs e)
    {
        if (ViewState["addmoreEdu"] != null)
        {
            myCount = (int)ViewState["addmoreEdu"];
        }
        myCount++;
        ViewState["addmoreEdu"] = myCount;
    
        TextBox txtboxcustom = new TextBox();
        Literal newlit = new Literal();
        newlit.Text = "<br /><br />";
        txtboxcustom.ID = "txtBoxcustom" + i.ToString();
        myPlaceHolder.Controls.Add(txtboxcustom);
        myPlaceHolder.Controls.Add(newlit);   
    }
