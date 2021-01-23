        foreach (Control ctrl in Page.Controls)
        {
            if (ctrl is TextBox)
            {
               
                ((TextBox)ctrl).Text = string.Empty;
            }
        }
    
