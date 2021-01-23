    string fName = txtfname.Text;
    if (string.IsNullOrWhiteSpace(fName) || fName.Any(Char.IsDigit))
    {
        MessageBox.Show("Please enter your First Name without digits");
        txtfname.Select();
    }
