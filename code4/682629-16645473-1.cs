       private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(comboBox2.SelectedIndex>0)
                {
                    con = new SqlCeConnection(s);
                    con.Open();
                    string code = "select CustomerID,Date_of_Allocation from lockerdetails    
                    where CustomerName='" + comboBox2.SelectedValue.ToString() + "'";
               
                    SqlCeDataAdapter da = new SqlCeDataAdapter(code, con);
                    SqlCeCommandBuilder cmd = new SqlCeCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    textBox1.Text = ds.Tables[0].Rows[0]["CustomerID"].ToString();
                    textBox5.Text = ds.Tables[0].Rows[0]["Date_of_Allocation"].ToString();
                }
            }
            catch(SystemException se)
            {
                MessageBox.Show(se.Message);
            }
