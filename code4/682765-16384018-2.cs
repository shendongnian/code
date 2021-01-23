    protected void btnClick_Click(object sender, EventArgs e)
    {
        List<string> listOfNames = Session["listOfNames"] as List<string>;
        if (listOfNames == null)
            Session["listOfNames"] = listOfNames = new List<string>();
        if (listOfNames.Contains(txtName.Text))
        {
            lblShow.Text = "Name already exists!";
        }
        else
        {
            listOfNames.Add(txtName.Text);
            lblShow.Text = String.Join("<br />", listOfNames);
        }
    }
