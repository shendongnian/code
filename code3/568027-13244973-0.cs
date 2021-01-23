    private void logFile()
        {
            StreamWriter logfile = null;
            logfile = File.AppendText(Server.MapPath("/CCTV_Files/log.txt"));
            try
            {
                logfile.Write(String.Format("{0:yyyyMMdd_hhmmss}", DateTime.Now) + " Frame added");
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (logfile != null)
                {
                    logfile.Close();
                }
            }
         }
