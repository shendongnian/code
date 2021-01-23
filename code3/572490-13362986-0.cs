    protected void Page_Load(object sender, EventArgs e)
    {
        switch (first_name.GetType().ToString())
        {
            case ("TextBox"):
                (first_name as TextBox).Text = "Your First Name...";
                break;
            case ("DropDownList"):
                (first_name as DropDownList).Items.Add("Jason");
                (first_name as DropDownList).Items.Add("Kelly");
                (first_name as DropDownList).Items.Add("Keira");
                (first_name as DropDownList).Items.Add("Sandi");
                (first_name as DropDownList).Items.Add("Gary");
                break;
            case ("CheckBox"):
                (first_name as CheckBox).Checked = true;
                break;
        }        
    }
