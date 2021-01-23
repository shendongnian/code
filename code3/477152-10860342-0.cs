    //change code to this to find the problem
    public void SiteNo()
    {
        Conhr.Open();
        //int anInteger;
        //anInteger = Convert.ToInt32(TextBox1.Text);
        //anInteger = int.Parse(TextBox1.Text);
        string sq = "select count(SiteCode) from tbl_SiteMaster where  Sitealiasname='" + ddlsite.SelectedItem.Text + "' ";
        SqlCommand d = new SqlCommand(sq, Conhr);
        SqlDataReader r;
        r = d.ExecuteReader();
        while (r.Read())
        {
            TextBox1.Text = r.GetValue(0).ToString();
        }
        r.close();
        Conhr.Close();
    }
