    SqlConnection con = new SqlConnection( "Data Source=localhost/SQLEXPRESS.Polaris.dbo;Initial Catalog=Polaris;Integrated Security=True;Pooling=False");
    protected void Button3_Click(object sender, EventArgs e)
    {
        con.Open();
        string s1 = "insert into Login values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + DropDownList1.SelectedItem.Value + "'";
        SqlCommand cmd = new SqlCommand(s1, con);
        cmd.ExecuteNonQuery();
    }
