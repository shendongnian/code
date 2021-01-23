    int counter = 0;
    // The counter variable must be global
    foreach (GridViewRow row in GridView1.Rows)         
    {           
        var chk = row.FindControl("myCheckBox") as CheckBox;
        if (chk.Checked)
        {
            counter++;
            var email = row.FindControl("LabelEmail") as Label;
            if (counter <= 1)
            txtEmails.Text += email.Text;
            else
            txtEmails.Text += ", " + email.Text;
        }
    }
