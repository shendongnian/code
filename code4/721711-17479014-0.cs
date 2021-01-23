      private void Form1_Load(object sender, EventArgs e)
      {
          try
                {
                    SqlDataReader datareader = qu.GetValue("English_Short");
                    AutoCompleteStringCollection local = new AutoCompleteStringCollection();
                    if (datareader.HasRows == true)
                    {
                        while (datareader.Read())
                            local.Add(datareader["English_Short"].ToString());
                    }
                    txt_Name.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txt_Name.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt_Name.AutoCompleteCustomSource = local;
                }
                catch (Exception ex)
                { 
                  MessageBox.Show(ex.Message);
                }
            }
      }
