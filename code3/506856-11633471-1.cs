    private bool countClick()
    {
        if (Session["clicks"] == null)
        {
            Session["clicks"] = 1;
            return true;
        }
        if (++((int)Session["clicks"]) > 1)
        {
             Response.Write("...");
             return false;
        }
        return true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (countClick())
        {
            Button1.Text = "Booked";
            Button1.BackColor = System.Drawing.Color.Blue;
            Button2.Text = "Booked";
            Button2.BackColor = System.Drawing.Color.Blue;
        }
    }
