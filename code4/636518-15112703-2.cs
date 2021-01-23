    public void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["addmoreEdu"] != null)
        {
            myCount = (int)ViewState["addmoreEdu"];
        }
        addControls(myCount);
    }
    public void addmoreCustom_Click(object sender, EventArgs e)
    {
        if (ViewState["addmoreEdu"] != null)
        {
            myCount = (int)ViewState["addmoreEdu"];
        }
        myCount++;
        ViewState["addmoreEdu"] = myCount;
        addControls(1);
    }
    private void addControls(int count)
    {
        int txtCount = myPlaceHolder.Controls.OfType<TextBox>().Count();
        for (int i = 0; i < count; i++)
        {
            TextBox txtboxcustom = new TextBox();
            Literal newlit = new Literal();
            newlit.Text = "<br /><br />";
            txtboxcustom.ID = "txtBoxcustom" + txtCount.ToString();
            myPlaceHolder.Controls.Add(txtboxcustom);
            myPlaceHolder.Controls.Add(newlit);
        }
    }
