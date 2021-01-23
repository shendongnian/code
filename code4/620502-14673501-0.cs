    protected void btnSend_Click(object sender, EventArgs e)
    {
        int age;
        if (int.TryParse(txtAge.Text, out age));
        {
            if (age <= 12)
                litResult.Text = "You are a child";
        }
        else
            litResult.Text = "Please enter a valid age";
    }
