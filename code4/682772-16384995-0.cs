    private string _listofcharacters = "listOfCharacters";
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session[_listofcharacters] == null)
        {
            Session.Add(_listofcharacters, new List<Character>());
        }
        List<Character> listOfCharacters = (List<Character>)Session[_listofcharacters];
        lblShow.Text = "";
        var check = from p in listOfCharacters
                    where p.Name.ToLower().Contains(txtName.Text.ToLower())
                    select p;
        if (check.Count() == 0)
        {
            listOfCharacters.Add(new Character() { Name = txtName.Text });
            foreach (Character item in listOfCharacters)
            {
                lblShow.Text += "Name: " + item.Name + "<br />";
            }
        }
        else
        {
            lblShow.Text = "Name already exists!";
        }
    }
