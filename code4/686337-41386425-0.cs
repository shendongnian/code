    public void SaveDataTable(DataTable DT)
            {
            try
                {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM {0}", DT.TableName);
                adapter = new SQLiteDataAdapter(cmd);
                SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
                adapter.Update(DT);
                con.Close();
                }
            catch (Exception Ex)
                {
                System.Windows.MessageBox.Show(Ex.Message);
                }
