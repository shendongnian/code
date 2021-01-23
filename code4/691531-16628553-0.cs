    private void button1_Click(object sender, EventArgs e)
    {
          SqlConnection con = new SqlConnection(@" Data Source=HOME-D2CADC8D4F\SQL;Initial Catalog=motociclete;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        int row = new_tab_Object.CurrentCell.RowIndex;
                
                if (row)
                {
                    new_tab_Object.Rows.RemoveAt(row);                
                
                try
                {
                    con.Open();
                    cmd.CommandText = "Delete from motociclete where codm=" + row + "";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        
        this.Close();
      }
