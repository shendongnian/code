    protected void Button1_Click(object sender, EventArgs e) 
    { 
         con.Open(); 
         SqlCommand cmd1 = new SqlCommand("insert into dbo.FillTable values (@TextBox2Val, @TextBox1Val, 'FA0005')", con); 
         cmd1.AddParameterWithValue( "TextBox1Val", TextBox1.Text );
         cmd1.AddParameterWithValue( "TextBox2Val", TextBox2.Text );
         SqlDataAdapter dr = new SqlDataAdapter(cmd1); 
         con.Close(); 
         DataSet dl = new DataSet(); 
         dr.Fill(dl); 
    } 
