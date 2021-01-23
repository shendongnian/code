    if (CheckBoxPersonalInfo.Items[0].selected)
    {
       LabelFirstName.Text = theEmpl.firstname;
    }
    else 
    {
        LabelFirstName.Text = "";
    }
    if (CheckBoxPersonalInfo.Items[1].selected)
    {
        LabelLastName.Text = theEmpl.lastname;
    }
    else 
    {
        LabelLastName.Text = "";
    }
