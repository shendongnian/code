    SC = new SqlConnection(ConfigurationManager.ConnectionStrings["BABBLER"].ConnectionString);
    SC.Open();
    CMD = new SqlCommand("Select * from TABLE1 WHERE COLUMN1= '" + TextBox1.Text + "' and  COLUMN2 Between '" + TextBox2.Text + "'" + " and " + "'" + TextBox3.Text + "'", SC);
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(CMD);
    da.Fill(ds);
    
    string data="";
    for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
    {
       
       if(data=="")
       {
          label1.Text = ds.Tables[0].Rows[i]["COLUMN2"].ToString();
       }
       else
       {
          label1.Text +=","+ ds.Tables[0].Rows[i]["COLUMN2"].ToString();
       }
      
    }
