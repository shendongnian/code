    for (int i = 0; i < dataGridView2.Rows.Count; i++)
    {
    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ID_Proof;Integrated Security=True");
                            SqlCommand cmd = new SqlCommand("INSERT INTO Restaurant (Customer_Name,Quantity,Price,Category,Subcategory,Item,Room_No,Tax,Service_Charge,Service_Tax,Order_Time) values (@customer,@quantity,@price,@category,@subcategory,@item,@roomno,@tax,@servicecharge,@sertax,@ordertime)", con);
                            cmd.Parameters.AddWithValue("@customer",dataGridView2.Rows[i].Cells[0].Value);
                            cmd.Parameters.AddWithValue("@quantity",dataGridView2.Rows[i].Cells[1].Value);
                            cmd.Parameters.AddWithValue("@price",dataGridView2.Rows[i].Cells[2].Value);
                            cmd.Parameters.AddWithValue("@category",dataGridView2.Rows[i].Cells[3].Value);
                            cmd.Parameters.AddWithValue("@subcategory",dataGridView2.Rows[i].Cells[4].Value);
                            cmd.Parameters.AddWithValue("@item",dataGridView2.Rows[i].Cells[5].Value);
                            cmd.Parameters.AddWithValue("@roomno",dataGridView2.Rows[i].Cells[6].Value);
                            cmd.Parameters.AddWithValue("@tax",dataGridView2.Rows[i].Cells[7].Value);
                            cmd.Parameters.AddWithValue("@servicecharge",dataGridView2.Rows[i].Cells[8].Value);
                            cmd.Parameters.AddWithValue("@sertax",dataGridView2.Rows[i].Cells[9].Value);
                            cmd.Parameters.AddWithValue("@ordertime",dataGridView2.Rows[i].Cells[10].Value);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Added successfully!");
