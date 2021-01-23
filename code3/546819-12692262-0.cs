    protected void Button1_Click(object sender, EventArgs e) 
    { 
         con.Open(); 
         SqlCommand cmd1 = new SqlCommand(string.Format("insert into dbo.FillTable values ('{0}', '{1}', 'FA0005')", TextBox2.Text, TextBox1.Text), con); 
         SqlDataAdapter dr = new SqlDataAdapter(cmd1); 
         con.Close(); 
         DataSet dl = new DataSet(); 
         dr.Fill(dl); 
    } 
