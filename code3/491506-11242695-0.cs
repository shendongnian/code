    foreach (Control c in panPrev.Controls)
    {
        if (c is ComboBox) 
        {
            (c as ComboBox).DataSource = ds01.Tables[0];
            (c as ComboBox).DisplayMember = "cars";
        }
    }
