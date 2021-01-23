    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        var query =
            "?filter1=" + TxtFilter1.Text +
            "&filter2=" + TxtFilter2.Text +
            "&filter3=" + TxtFilter3.Text; // etc.
        Response.Redirect(query);
    }
