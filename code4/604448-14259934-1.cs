        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e) //or CellValidating Event
        {
            try
            {
                if (dataGridView1.IsCurrentRowDirty) //use IsCurrentCellDirty if you choose CellValidating Event
                {
                    con.ConnectionString = "Data Source=CHANDU-PC;Initial Catalog=Class;Integrated Security=true;MultipleActiveResultSets=true;";
                    con.Open();
                    SqlCommand cmd;
                    string studentId = dataGridView1[0, e.RowIndex].EditedFormattedValue.ToString();
                    string lastname = dataGridView1[1, e.RowIndex].EditedFormattedValue.ToString();
                    string firstname = dataGridView1[2, e.RowIndex].EditedFormattedValue.ToString();
                    string myQry;
                    //I use int.Parse to Convert the string to int, 
                    if (int.Parse(studentId) == 0) //Get Primary key (hint null, 0, or -1 value to insert the data)
                    {
                        //Insert
                        myQry = @"insert intro student1 (lastname, firstname) Values ('" + lastname + "', '" + firstname + "')";
                    }
                    else
                    {
                        //Update
                        myQry = @"update student1 set lastname = '" + lastname + "', firstname = '" + firstname + "'" + " Where studentId = '" + studentId + "'";
                    }
                    cmd = new SqlCommand(myQry, con);
                    da.SelectCommand = cmd;
                    cmd.ExecuteNonQuery();
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught : " + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    con.ConnectionString = "Data Source=CHANDU-PC;Initial Catalog=Class;Integrated Security=true;MultipleActiveResultSets=true;";
                    con.Open();
                    SqlCommand cmd;
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        string delQry = @"delete from student1 where studentId = '" + item.Cells[0].EditedFormattedValue.ToString() + "'";
                        cmd = new SqlCommand(delQry, con);
                        da.SelectCommand = cmd;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
