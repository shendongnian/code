    using(OleDbConnection myCon = new OleDbConnection(ConfigurationManager.ConnectionStrings["DbConn"].ToString()))
    {
       OleDbCommand cmd = new OleDbCommand(); 
       cmd.CommandType = CommandType.Text; 
       cmd.CommandText = "insert into Items ([Item_Name],[Item_Price]) values (?,?);
       cmd.Parameters.AddWithValue("@item", itemNameTBox.Text);
       cmd.Parameters.AddWithValue("@price", Convert.ToDouble(itemPriceTBox.Text)); 
       cmd.Connection = myCon; 
       myCon.Open(); 
       cmd.ExecuteNonQuery(); 
       System.Windows.Forms.MessageBox.Show("An Item has been successfully added", "Caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Information); 
    }
