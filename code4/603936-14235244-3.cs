    string gender;
    if (radio_male.Checked)
    {
        gender = "Male";
    }
    else if (radio_female.Checked)
    {
        gender = "Female";
    }
    else
    {
        gender = "";
    }
    txtfirstname.Text = gender;
