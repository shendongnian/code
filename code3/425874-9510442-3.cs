     private void childDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
     {
         try
         {
              SQL.createTable("childDirectory"); //THIS LINE
         }
         catch(SystemException ecp)
         {
            MessageBox.Show(string.Format("An error occurred: {0}", ecp.Message));
         }
         catch (SqlException exp)
         {               
             
         }
     }
