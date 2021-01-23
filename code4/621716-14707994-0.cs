    foreach (Control c in form1.Controls)
    {
        TextBox txtdynamic = c as TextBox;
    
        if (txtdynamic  != null)
        {
            txtdynamic .text="Sherif";
        }
    }
