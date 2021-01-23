    protected void Button1_Click(object sender, EventArgs e)
    {
     SqlConnection con = new SqlConnection("server=AMR\\DEV1;UID=po;PWD=12W; database=POM;");
     con.Open();
     SqlCommand cmd = new SqlCommand("select * from budget where id=@id and amount=amount", con);
     cmd.Parameters.AddWithValue("@id",TextBox1.Text);
     cmd.Parameters.AddWithValue("@amount",TextBox2.Text);
     DataSet ds = new DataSet();
     ds.Clear();
     SqlDataAdapter da = new SqlDataAdapter(cmd);
     da.Fill(ds);
     if (ds.Tables[0].Rows.Count > 0) 
     {
        Session["user"] = ds.Tables[0].Rows[0][0].ToString();
        Response.Redirect("Default2.aspx");
     }
      else {
        TextBox1.Text = "";
        TextBox2.Text = "";
        Label1.Text = "Invalid Login Details!";
     }
    }
