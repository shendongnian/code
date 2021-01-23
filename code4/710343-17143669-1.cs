    foreach (Control c in deliveryGroup.Controls)
    {
        if (c is Label || c is Button)
        {
            c.TabStop = false;
        }
        else
        {
            if (c.Name == "cmbPKPAdrID")
            {
            }
            else if (c.Name.ToString() == "cmbPKPType")
            {
                c.TabStop = true;
            }
            else if (c.Name.ToString() == "dtpPKPDate")
            {
                c.TabStop = true;
            }
            else
            {
                c.TabStop = string.IsNullOrEmpty(c.Text);
            }
        }
    }
