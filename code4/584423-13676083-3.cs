    if (tb.Name == "Mag Data")
    {
        Control[] cntrl = Controls.Find("Card Number", true);
        if (cntrl.Length != 0)
        {
            ((TextBox)cntrl[0]).Text = tb.Text;
        }
    }
