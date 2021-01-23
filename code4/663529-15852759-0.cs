        private void saveDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BackupDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " \nPlease choose the folder Sauvegardes to backup !");
            }
            
        }
        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RestoreDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BackupDatabase()
        {
            saveFileDialogBackUp.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Sauvegardes";
            if (saveFileDialogBackUp.ShowDialog() == DialogResult.OK)
            {
                Con.ExecuteCmd("BACKUP DATABASE MyFooDatabase TO DISK = '" + saveFileDialogBackUp.FileName + "'");
                MessageBox.Show("Success , done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void RestoreDatabase()
        {
            openFileDialogBackUp.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"Sauvegardes";
            if (openFileDialogBackUp.ShowDialog() == DialogResult.OK)
            {
                Con.ExecuteCmd(" USE MASTER RESTORE DATABASE MyFooDatabase FROM DISK = '"+openFileDialogBackUp.FileName+"' WITH REPLACE");
                MessageBox.Show("Database Restored", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
