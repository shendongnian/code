    private void btnInsert_Click(object sender, EventArgs e)
            {
                SqlCeCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Tb (Ch1, Chl2) VALUES (?, ?)";
                cmd.Parameters.Add(new SqlCeParameter("p1", SqlDbType.NText));
                cmd.Parameters.Add(new SqlCeParameter("p2", SqlDbType.Int));
                cmd.Parameters["p1"].Size = 50;
                cmd.Prepare();
                cmd.Parameters["p1"].Value =textBox1.Text;
                cmd.Parameters["p2"].Value =textBox2.Text;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                displayTable();
           
            }
      private void displayTable()
            {
               SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Tb", con1);
               SqlCeDataReader reader = cmd.ExecuteReader();
               DataTable table = new DataTable();
               table.Columns.Add("Ch1", typeof(int));
               table.Columns.Add("Ch2", typeof(string));
               while (reader.Read())
               {
                   table.Rows.Add(reader.GetInt32(0), reader.GetString(1));
               }
               reader.Close();
               dataGrid1.DataSource = table;
          
            }
 
