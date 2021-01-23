    protected void btnSave_Click(object sender, EventArgs e)
    {
       foreach(DataRow row in dt.Rows)
       {
         SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["constring"]);
         SqlCommand cmd = new SqlCommand();
         cmd.CommandText = "INSERT INTO YOUR_TABLE_NAME (NAME, CITY) VALUES (" + row["Name"].ToString() + "," + row["City"].ToString() + ")";
         int numRegs = cmd.ExecuteNonQuery();
       }
    }
