    try
    {
        if (this.Open())
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            this.Close();
            System.Windows.Forms.MessageBox.Show("Record Inserted!");
        }
    }
    catch(Exception ex)
    {
        this.Close();
        System.Windows.Forms.MessageBox.Show(String.Format("INSERT Record Error! {0}", ex.Message));
    }
