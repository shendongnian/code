    protected void Button1_Click(object sender, EventArgs e)
    {
        Int32 TotalRecords = 0;
        SqlConnection con = new SqlConnection("data source=.\; Integrated Security=SSPI; initial catalog=Testdb;User ID=sa;password=abc123;");            
        foreach (GridViewRow gvRow in GridView1.Rows)
        {            
            TextBox textBox1 = (TextBox)gvRow.FindControl("textBox1");
            String q = "INSERT INTO details ([name]) VALUES('" + textBox1.Text.Trim() + "')";
            SqlCommand cmd = new SqlCommand(q, con);
                
            con.Open();
            TotalRecords += cmd.ExecuteNonQuery();
            con.Close();
        }
        lblMessage.Text = "Total " + TotalRecords + " inserted successfully.";
    }
