    protected void Login_Click(object sender, EventArgs e)
        {
            string conString = "Provider=Microsoft.JET.OLEDB.4.0; data source=" + Server.MapPath (string.Empty)  + @"\Database\Northwind.mdb";
            string sqlString = "SELECT * FROM CUSTOMERS where CustomerID='" + TextBox1.Text + "' and City='" + TextBox2.Text + "'";
            OleDbConnection conn = new OleDbConnection(conString);
            DataSet ds = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlString, conn);
            adapter.Fill(ds);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LoginID"] = ds.Tables[0].Rows[0]["CustomerID"].ToString();
                    Response.Redirect("Welcome.aspx");
    
                }
                else
                    Label1.Text = "Enter correct id/city";
            }
    
           
        }
    }
