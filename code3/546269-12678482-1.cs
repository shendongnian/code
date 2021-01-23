    foreach(var control in splitContainer2.Controls)
    {
        if(control is Panel)
        {
            ((Panel)control).Visible = ((Panel)control).Name == panel_name;
        }
    }
