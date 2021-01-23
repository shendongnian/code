    private void button3_Click(object sender, EventArgs e)
    {
        Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(provider);
        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand();
        try
        {
            conn.Open();
            cmd = new Oracle.DataAccess.Client.OracleCommand(" DELETE * from CURSE  WHERE ID_CURSA  = '" +   textBox1.Text + "'", conn);
            cmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
            if(ex.InnerException != null)
                MessageBox.Show(ex.InnerException.Message);
        }
        finally
        {
            conn.Close();
        }
    }
