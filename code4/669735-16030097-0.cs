              try
                {
    
                    con.Open();
    
                    str = "select * from [sheet1$]";
    
                    com = new OleDbCommand(str, con);
    
                    oledbda = new OleDbDataAdapter(com);
    
                    ds = new DataSet();
    
                    oledbda.Fill(ds, "[sheet1$]");
    
                    con.Close();
    
                    dt = ds.Tables["[sheet1$]"];
    
                    int i = 0;
    
                    for (i = 0; i <= dt.Rows.Count -1; i++)
    
                    {
    
                        comboBox1.Items.Add(dt.Rows[i].ItemArray[0]);
    
                    }
    
                }
    
                catch (Exception ex)
                    {
    
                    MessageBox.Show(ex.Message);
    
                }
    
     
            }
