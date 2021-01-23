      for (i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                string ConnectionString2 = ConfigurationSettings.AppSettings["ConnectionString2"];
                MySqlConnection connection2;
                connection2 = new MySqlConnection(ConnectionString2);
                connection2.Open();
                
                    string day = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    string Desc = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string item = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string prod = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    string vol = dataGridView1.Rows[i].Cells[4].Value.ToString();
                    string qty = dataGridView1.Rows[i].Cells[5].Value.ToString();
                    MySqlCommand cmdwk = new MySqlCommand("INSERT INTO spt_proposal_line_lab (proposal_Id,day_Name,proposal_Desc,proposal_Vol,product_Id,proposal_Qty,item_Id) VALUES (@propid,@day,@desc,@vol,@prod,@qty,@item)", connection2);
                    MySqlParameter propid = new MySqlParameter("@propid", b);
                    MySqlParameter day1 = new MySqlParameter("@day", day);
                    MySqlParameter Desc1 = new MySqlParameter("@desc", Desc);
                    MySqlParameter vol1 = new MySqlParameter("@vol", vol);
                    MySqlParameter prod1 = new MySqlParameter("@prod", prod);
                    MySqlParameter qty1 = new MySqlParameter("@qty", qty);
                    MySqlParameter item1 = new MySqlParameter("@item", item);
                    cmdwk.Parameters.Add(day1);
                    cmdwk.Parameters.Add(propid);
                    cmdwk.Parameters.Add(Desc1);
                    cmdwk.Parameters.Add(prod1);
                    cmdwk.Parameters.Add(vol1);
                    cmdwk.Parameters.Add(qty1);
                    cmdwk.Parameters.Add(item1);
                    cmdwk.ExecuteNonQuery();
                }
            }
        }
    }
