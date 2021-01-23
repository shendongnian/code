     protected void Button1_Click(object sender, EventArgs e)
        {        
           con = new System.Data.OleDb.OleDbConnection();
           con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" 
           + "Data Source=C:\\Users\\sam\\Desktop\\mydb.mdb";
           con.Open();
           string sql = "SELECT * From Leave where userid="+Textbox1.Text;
           da = new System.Data.OleDb.OleDbDataAdapter(sql, con);
           DataTable t = new DataTable();
           da.Fill(t);
           GridView1.DataSource = t;
           GridView1.DataBind();
           con.Close();
        }
   
