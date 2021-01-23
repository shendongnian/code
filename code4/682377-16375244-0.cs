    private void BackupDatabase()
            {
                string time = DateTime.Now.ToString("dd-MM-yyyy");
                string savePath = AppDomain.CurrentDomain.BaseDirectory + @"Backups\"+time+"_"+saveFileDialogBackUp.FileName;
                if (saveFileDialogBackUp.ShowDialog() == DialogResult.OK)
                {
                    try {
                            using (Process mySqlDump = new Process())
                            {
                                mySqlDump.StartInfo.FileName = @"mysqldump.exe";
                                mySqlDump.StartInfo.UseShellExecute = false;
                                mySqlDump.StartInfo.Arguments = @"-u" + user + " -p" + pwd + " -h" + server + " " + database + " -r \"" + savePath + "\"";
                                mySqlDump.StartInfo.RedirectStandardInput = false;
                                mySqlDump.StartInfo.RedirectStandardOutput = false;
                                mySqlDump.StartInfo.CreateNoWindow = true;
                                mySqlDump.Start();
                                mySqlDump.WaitForExit();
                                mySqlDump.Close();
                            }
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Connot backup database! \n\n" + ex);
                        }
                    MessageBox.Show("Done! database backuped!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
    
