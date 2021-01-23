        public static bool SftpCSVFile(this DataTable dt, string ftpAddress, string username, string password, string port, string folderPath, string filename, string separator, string keyFilename, string keyPassword)
        {
            bool Success = false;
            Sftp sftp = null;
            try
            {
                if (filename.Length > 0 && dt != null)
                {
                    //Save local file
                    ToCSVFile(dt, filename, separator);
                    //Send file
                    int NumberOfConnectionAttempts = 0;
                JumpPoint:
                    try
                    {
                        sftp = new Sftp(ftpAddress, username);
                        sftp.Password = password;
                        sftp.AddIdentityFile(keyFilename, keyPassword);
                        // non-password alternative is sftp.AddIdentityFile(keyFilename);
                        sftp.Connect();
                        sftp.Put(filename + ".csv", (!String.IsNullOrWhiteSpace(folderPath) ? folderPath + "/" : "") + filename + ".csv");
                        Success = true;
                    }
                    catch (Exception ex)
                    {
                        Program.DisplayText(" Connection " + NumberOfConnectionAttempts + " failed.\n");
                        if (NumberOfConnectionAttempts < Program.IntTotalAllowedConnectionAttempts)
                        {
                            NumberOfConnectionAttempts++;
                            Thread.Sleep(1000);
                            goto JumpPoint;
                        }
                        else
                        {
                            //Program.HandleException(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Program.HandleException(ex);
            }
            finally
            {
                //Close sftp
                try { sftp.Close(); }
                catch { }
                try { sftp = null; }
                catch { }
                try { GC.Collect(); }
                catch { }
                //Delete local file
                try { File.Delete(filename); }
                catch { }
            }
            return Success;
        }
