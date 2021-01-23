    private void childDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
         try
         {
             SQL.createTable("childDirectory"); //THIS LINE
         }
         catch (SqlException ex)
         {
             MessageBox.Show("Database not created: " + ex.Message);
         }
         catch(SystemException ecp)
         {
             MessageBox.Show(string.Format("An error occurred: {0}", ecp.Message));
         }
    }
