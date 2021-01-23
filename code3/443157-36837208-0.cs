                        string fileName = txtEditFolderPath.Text + "\\" + txtEditDatabaseName.Text + ".sdf";
                         if (File.Exists(fileName))
                         {
                           MessageBox.Show("Database with this name already existed at this location !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         }
                         else
                         {
                             string connectionString;
                             string password = "123";
    
                             connectionString = string.Format(
                               "DataSource=\"{0}\"; Password='{1}'", fileName, password);
                             SqlCeEngine en = new SqlCeEngine(connectionString);
                             en.CreateDatabase();
                         }
