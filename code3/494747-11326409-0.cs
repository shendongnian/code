        if (txtIDD.Text == "")
        {
            MessageBox.Show("Please fill ID no. of record to Delete", "Important Message");
        }
        else
        {
            try
            {
                OleDbCommand Cmd = new OleDbCommand();
                Cmd.Connection = conn;
                conn.Open();
                Cmd.CommandText = "DELETE FROM AddressBook WHERE ID="+txtIDD.Text;
                Cmd.CommandType = CommandType.Text;
                Cmd.ExecuteNonQuery();
                Cmd.Connection.Close();
                conn.Close();
                
                //Call a method that binds the grid or get DataTable from database and bind it like this
                 dataGridView3.DataSource = dt;
                 dataGridView3.DataBind();
                dataGridView3.Update();
        
                MessageBox.Show("Delete Succesfull");
            }
            catch (System.Exception err)
            {
                this.label27.Visible = true;
                this.label27.Text = err.Message.ToString();
            }
        }
    }
