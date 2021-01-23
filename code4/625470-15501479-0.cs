        /// <summary>
        /// Var olan backup ın restore edilmesini sağlar
        /// </summary>
        /// <param name="NewDatabaseName">new database name</param>
        /// <param name="BackUpFile">backup file path</param>
        /// <param name="ServerName">server name</param>
        /// <param name="UserName">user name</param>
        /// <param name="Password">password</param>
        public void RestoreToDatabase(string NewDatabaseName, string BackUpFile, string ServerName, string UserName, string Password, string restorePath)
        {
            string provider = "Server    =" + ServerName +
                       ";Database =" + "master" +
                       ";User Id  =" + UserName +
                       ";password =" + Password +
                       "; Connect Timeout=2" +
                       ";Trusted_Connection=False";
            SqlConnection conn = new SqlConnection(provider);
            try
            {
                string ConnectionString = @"Data Source= " + ServerName + ";Initial Catalog=AudioMaster;Integrated Security=True";
                ServerConnection ServerConn = null;
                if (UserName == "" && Password == "")
                {
                    ServerConn = new ServerConnection(ServerName);
                }
                else if (UserName != "" && Password != "")
                {
                    ServerConn = new ServerConnection(ServerName, UserName, Password);
                }
                Server server = null;
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
                String[] instances = (String[])rk.GetValue("InstalledInstances");
                server = new Server(ServerConn);
            first:
                foreach (Microsoft.SqlServer.Management.Smo.Database db in server.Databases)
                {
                    if (NewDatabaseName == db.Name)
                    {
                        UpdateScreen("> Same database name detected", Color.Red);
                        NewDatabaseName = Microsoft.VisualBasic.Interaction.InputBox(NewDatabaseName + " database allready exist. Please enter new database name ",
                        "Database owerride error", "Enter a name");
                        UpdateScreen("> New database name : " + NewDatabaseName, Color.Green);
                        goto first;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteError(ex);
                UpdateScreen("> An error ocurred when database names searching operation. Details : " + ex.Message, Color.Red);
            }
            try
            {
                conn.Open();
                top :
                FileInfo file = new FileInfo(Path.Combine(dirDebug, "scriptTry.txt"));
                string mdfName = String.Empty;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = file.OpenText().ReadToEnd();
                cmd.Connection = conn;
                cmd.Parameters.Add("@Path", BackUpFile);
                cmd.Parameters.Add("@RestorePath", restorePath);
                cmd.Parameters.Add("@databaseName", NewDatabaseName);
                mdfName = cmd.ExecuteScalar().ToString();
                string[] names = Directory.GetFiles(restorePath, "*.mdf");
           
                int sayac = 0;
                for(int i=0; i<names.GetLength(0); i++) 
                {
                    if (mdfName == GetSubPath(names[i].Replace(".mdf", "")))
                        sayac++;
                }
                if (sayac !=0)
                {
                    MessageBox.Show("Please enter new directory for database *.mdf and *.ldf file", "Database owerride error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    try
                    {
                        UpdateScreen("> Same path detected for *.mdf and *.ldf file.", Color.Red);
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                        fbd.ShowDialog();
                        if (fbd.SelectedPath == "")
                            return;
                        else
                        {
                            restorePath = fbd.SelectedPath + "\\";
                        }
                        UpdateScreen("> Selected new path for *.mdf and *.ldf file : " + fbd.SelectedPath, Color.Green);
                        goto top; 
                    }
                    catch (Exception exx)
                    {
                        WriteError(exx);
                        UpdateScreen("> An error ocurred when database restore. Details : " + exx.Message, Color.Red);
                    }
                }
                file = new FileInfo(Path.Combine(dirDebug, "backup script.txt"));
                cmd = new SqlCommand();
                cmd.CommandText = file.OpenText().ReadToEnd();
                cmd.Connection = conn;
                cmd.Parameters.Add("@Path", BackUpFile);
                cmd.Parameters.Add("@RestorePath", restorePath);
                cmd.Parameters.Add("@databaseName", NewDatabaseName);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                WriteError(ex);
            }
        }
